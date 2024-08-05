using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

// v 1.5
// Made By Abdul Akhundzada

namespace Snake.cs
{
    public partial class Snake : Form
    {
        // саундтрек
        private static string[] musicNames = new string[3] {
            "Late_Truth",
            "Loose_Slip",
            "Luck_Witch"
        };
        private static int musicID = 0;

        // началась ли игра
        private bool gameStarts = false;

        // скорость (раз во сколько миллисекунд зарабатывает таймер)
        private int speed = 125;

        // количество очков
        private int score = 1;

        // координаты генерации фрукта
        private int rI, rJ;

        // максимальное число ячеек в змее
        const int MAXCELLS = 100;

        // модель фрукта и массив моделей змеи
        private PictureBox fruit;
        private PictureBox[] snake = new PictureBox[MAXCELLS];

        // движение по X и Y
        private int dirX, dirY;

        // ширина и высота экрана
        private int _width = 700;
        private int _height = 600;

        // размер кубика
        private int _sizeOfSlides = 40;

        // настройки игры
        private bool goesThroughWall = true; // проходит через стены (на другую сторону)
        private bool decreasesThroughWall = false; // уменьшается при попытке пройти через стену

        private bool eatsHimself = true; // может кушать себя (при этом лишается скушанного места)
        private bool killsHimself = false; // умирает, если скушает себя

        private bool _useSoundTrack = true;
        private bool _usedSoundTrack = true;

        // саундтрек
        private static SoundPlayer[] soundTracks = new SoundPlayer[musicNames.Length];

        public Snake()
        {
            InitializeComponent();

            // название
            this.Text = "Snake";

            this.Controls.Clear();

            // цвет во время настроек
            this.BackColor = Color.GreenYellow;

            // запуск игры
            _startgame();

            // запуск таймера и управления игры
            if (!gameStarts)
            {
                // игра
                timer.Interval = speed;
                timer.Tick += new EventHandler(_update);

                // отслеживание нажатий
                this.KeyDown += new KeyEventHandler(OKP);

                gameStarts = true;
            }
            timer.Start();

            // запускает саундтрек
            soundTracks[0] = new SoundPlayer(musicName(0));
            soundTracks[1] = new SoundPlayer(musicName(1));
            soundTracks[2] = new SoundPlayer(musicName(2));

            soundTracks[0].PlayLooping();
        }

        private string musicName(int musicID)
        {
            return string.Format(@"{0}\{1}{2}", "Music", (musicNames[musicID]).ToString(), ".wav");
        }

        // если змейка выйдет за пределы экрана, то выйдет с другой стороны
        private void _checkborders()
        {
            // если пользователь в настройках решил проходить через стены (на другую сторону)
            if (goesThroughWall)
            {
                // если змейка пойдёт через левый "забор"
                if (snake[0].Location.X < 1)
                {
                    snake[0].Location = new Point(_width - 179, snake[0].Location.Y);
                }

                // если змейка пойдёт через правый "забор"
                if (snake[0].Location.X > _width - 179)
                {
                    snake[0].Location = new Point(1, snake[0].Location.Y);
                }

                // если змейка пойдёт через верхний "забор"
                if (snake[0].Location.Y < 1)
                {
                    snake[0].Location = new Point(snake[0].Location.X, _height - 79);
                }

                // если змейка пойдёт через нижний "забор"
                if (snake[0].Location.Y > _height - 79)
                {
                    snake[0].Location = new Point(snake[0].Location.X, 1);
                }
            }

            // если пользовательв настройках решил, что змейка будет уменьшаться при попытке пройти через стену
            if (decreasesThroughWall)
            {
                for (int _i = 2; _i <= score; _i++)
                {
                    this.Controls.Remove(snake[_i]);
                }

                // если змейка пойдёт через левый "забор"
                if (snake[0].Location.X < 1)
                {
                    score = 1;
                    dirX = 1;
                    dirY = 0;
                }

                // если змейка пойдёт через правый "забор"
                if (snake[0].Location.X > _width - 179)
                {
                    score = 1;
                    dirX = -1;
                    dirY = 0;
                }

                // если змейка пойдёт через верхний "забор"
                if (snake[0].Location.Y < 1)
                {
                    score = 1;
                    dirY = 1;
                    dirX = 0;
                }

                // если змейка пойдёт через нижний "забор"
                if (snake[0].Location.Y > _height - 79)
                {
                    score = 1;
                    dirY = -1;
                    dirX = 0;
                }
            }
        }

        // если змейка попробует съесть саму себя, то до лишится всех квадратов до места укуса
        private void _eatitself()
        {
            // если пользователь указал в настройках, что змейка будет кушать себя (удалится скушанная часть)
            if (eatsHimself)
            {
                // удаление квадратов до места укуса
                for (int _i = 1; _i < score; _i++)
                {
                    if (snake[0].Location == snake[_i].Location)
                    {
                        for (int _j = _i; _j <= score; _j++)
                        {
                            this.Controls.Remove(snake[_j]);
                        }

                        score = score - (score - _i + 1);
                    }
                }
            }

            // если пользователь указал в настройках, что змейка не будет кушать себя (игра начнётся заново)
            if (killsHimself)
            {
                // удаление квадратов до места укуса
                for (int _i = 1; _i < score; _i++)
                {
                    if (snake[0].Location == snake[_i].Location)
                    {
                        for (int _j = 2; _j <= score; _j++)
                        {
                            this.Controls.Remove(snake[_j]);
                        }

                        score = 1;
                    }
                }
            }
        }

        // правильное движение змеи
        private void _moveSnake()
        {
            // цикл движения змеи
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }

            snake[0].Location = new Point(snake[0].Location.X + dirX * (_sizeOfSlides), snake[0].Location.Y + dirY * (_sizeOfSlides));

            // если он съест самого себя
            _eatitself();
        }

        // если голова змеи пройдёт через фрукт, она съест его, и получит очки (квадраты тоже)
        private void _eatfruit()
        {
            // если координаты змеи и фрукта совпадают
            if (snake[0].Location.X == rI && snake[0].Location.Y == rJ)
            {
                // уеличение очков
                score++;

                // создание нового квадрата
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + _sizeOfSlides * dirX, snake[score - 1].Location.Y - _sizeOfSlides * dirY);
                snake[score].Size = new Size(_sizeOfSlides - 1, _sizeOfSlides - 1);
                snake[score].BackColor = Color.Blue;

                // добавление нового квадрата
                this.Controls.Add(snake[score]);

                // генерация нового фрукта
                _generatefruit();
            }
        }

        // если змея уже съела фрукт, генерирует новый
        private void _generatefruit()
        {
            // генерация фрукта в рандомном месте в заданном диапазоне
            Random r = new Random();

            // по вертикали от нуля до ширины экрана минус место для фрукта
            rI = r.Next(_sizeOfSlides, _height - 2*_sizeOfSlides);

            // по горизонтали от нуля до высоты экрана минус место для фрукта
            rJ = r.Next(_sizeOfSlides, _height - 2*_sizeOfSlides);

            // вычитаем от полученных координат модуль деления на размер одной клетки
            rI -= rI % _sizeOfSlides;
            rJ -= rJ % _sizeOfSlides;

            // добавляем один (чтобы квадрат не закрывал сетку)
            rI++;
            rJ++;

            // задаём координаты фрукта
            fruit.Location = new Point(rI, rJ);

            // добавляем фрукт
            this.Controls.Add(fruit);
        }

        // генерация карты (квадратная сетка)
        private void _generateMap()
        {
            // горизонтально
            for (int i = 0; i <= _width / _sizeOfSlides; i++)
            {
                // создаёт отрезок
                PictureBox picture = new PictureBox();
                picture.BackColor = Color.Black;
                picture.Location = new Point(0, _sizeOfSlides * i);
                picture.Size = new Size(_width - 100, 1);

                // добавляет отрезок
                this.Controls.Add(picture);
            }

            // вертикально
            for (int i = 0; i <= _height / _sizeOfSlides; i++)
            {
                // создаёт отрезок
                PictureBox picture = new PictureBox();
                picture.BackColor = Color.Black;
                picture.Location = new Point(_sizeOfSlides * i, 0);
                picture.Size = new Size(1, _width);

                // добавляет отрезок
                this.Controls.Add(picture);
            }
        }

        // вызывает все нужные методы игры по очереди
        private void _update(object my_object, EventArgs eventsArgs)
        {
            // если змея натыкается на фрукт, кушает его
            _eatfruit();
            // проверяет, если змея вышла за пределы экрана
            _checkborders();
            // двигет змейку
            _moveSnake();
        }

        // отслеживает нажатие клавиш
        private void OKP(object sender, KeyEventArgs e)
        {
            // движение вправо
            if (e.KeyCode.ToString() == "Right" || e.KeyCode.ToString() == "D")
            {
                // если змея идёт налево, она не может сразу пойти направо (она должна повернуться)
                // если у змеи только один кубик, то она может
                if (dirX != -1 && snake[0].Location.X + _sizeOfSlides != snake[1].Location.X)
                {
                    dirX = 1;
                    dirY = 0;
                }
            }

            // движение влево
            if (e.KeyCode.ToString() == "Left" || e.KeyCode.ToString() == "A")
            {
                // если змея идёт направо, она не может сразу пойти налево (она должна повернуться)
                // если у змеи только один кубик, то она может
                if (dirX != 1 && snake[0].Location.X - _sizeOfSlides != snake[1].Location.X)
                {
                    dirX = -1;
                    dirY = 0;
                }
            }

            // движение вверх
            if (e.KeyCode.ToString() == "Up" || e.KeyCode.ToString() == "W")
            {
                // если змея идёт вниз, она не может сразу пойти вверх (она должна повернуться)
                // если у змеи только один кубик, то она может
                if (dirY != 1 && snake[0].Location.Y - _sizeOfSlides != snake[1].Location.Y)
                {
                    dirY = -1;
                    dirX = 0;
                }
            }

            // движение вниз
            if (e.KeyCode.ToString() == "Down" || e.KeyCode.ToString() == "S")
            {
                // если змея идёт верх, она не может сразу пойти низ (она должна повернуться)
                // если у змеи только один кубик, то она может
                if (dirY != -1 && snake[0].Location.Y + _sizeOfSlides != snake[1].Location.Y)

                {
                    dirY = 1;
                    dirX = 0;
                }
            }


            // открыть настройки
            if (e.KeyCode.ToString() == "F")
            {
                // удаляем все элементы
                this.Controls.Clear();

                // изменяем высоту
                this.Height = _height - 200;

                // отключаем таймер
                timer.Stop();

                // удаляем змейку
                Array.Clear(snake, 1, 98);

                // убираем очки
                score = 1;

                // добавляем элементы
                this.Controls.Add(buttonGoesThroughWall);
                this.Controls.Add(buttonDecreasesThroughWall);
                this.Controls.Add(buttonEatsHimself);
                this.Controls.Add(buttonKillsHimself);
                this.Controls.Add(buttonSettings);
                this.Controls.Add(buttonEndSettings);
                this.Controls.Add(SoundTrackButton);
                this.Controls.Add(musicNameButton);
            }

            // эту иигру делал Абдул Ахундзаде
            if (e.KeyCode.ToString() == "X")
            {
                // удаляем все элементы
                this.Controls.Clear();

                // изменяем высоту
                this.Height = _height - 200;

                // отключаем таймер
                timer.Stop();

                // удаляем змейку
                Array.Clear(snake, 1, 98);

                // убираем очки
                score = 1;

                // изменяем расположение
                MadeBy.Location = new Point(192, 30);
                AbdulAkhundzade.Location = new Point(237, 140);

                // добавляем элементы
                this.Controls.Add(MadeBy);
                this.Controls.Add(buttonEndSettings);
                this.Controls.Add(AbdulAkhundzade);
            }

            // пауза
            if (e.KeyCode.ToString() == "Space")
            {
                _pause();
            }
        }

        // пауза
        private void _pause()
        {
            if (timer.Enabled == true)
            {
                timer.Stop();

                if (_useSoundTrack)
                {
                    soundTracks[musicID].Stop();
                    _usedSoundTrack = false;
                }
            }
            else
            {
                timer.Start();

                if (_useSoundTrack)
                {
                    soundTracks[musicID].PlayLooping();
                    _usedSoundTrack = true;
                }
            }
        }

        // начать игру
        private void _startgame()
        {
            // изменяет высоту, ширину и цвет экрана во время игры
            this.Height = _height;
            this.Width = _width;
            this.BackColor = Color.Lime;

            // чтобы змейка не была видна за картой
            empty.Location = new Point(561, 0);
            this.Controls.Add(empty);

            // движение по X и Y
            dirX = 1;
            dirY = 0;

            // создание змейки (в начале игры только два элемента)
            snake[0] = new PictureBox();
            snake[0].Location = new Point(201, 201);
            snake[0].Size = new Size(_sizeOfSlides - 1, _sizeOfSlides - 1);
            snake[0].BackColor = Color.Blue;

            snake[1] = new PictureBox();
            snake[1].Location = new Point(201, 201);
            snake[1].Size = new Size(_sizeOfSlides - 1, _sizeOfSlides - 1);
            snake[1].BackColor = Color.Blue;

            this.Controls.Add(snake[0]);
            this.Controls.Add(snake[1]);

            // фрукты
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(_sizeOfSlides, _sizeOfSlides);

            // генерация карты
            _generateMap();

            // генерация фрукта
            _generatefruit();

            if (!_useSoundTrack) soundTracks[musicID].Stop();
        }


        // настройки
        private void buttonGoesThroughWall_Click(object sender, EventArgs e)
        {
            goesThroughWall = true;
            decreasesThroughWall = false;

            // изменяет цвет кнопок
            buttonGoesThroughWall.BackColor = Color.LimeGreen;
            buttonDecreasesThroughWall.BackColor = Color.OrangeRed;
        }

        private void buttonDecreasesThroughWall_Click(object sender, EventArgs e)
        {
            goesThroughWall = false;
            decreasesThroughWall = true;

            // изменяет цвет кнопок
            buttonDecreasesThroughWall.BackColor = Color.LimeGreen;
            buttonGoesThroughWall.BackColor = Color.OrangeRed;
        }

        private void buttonKillsHimself_Click(object sender, EventArgs e)
        {
            killsHimself = true;
            eatsHimself = false;

            // изменяет цвет кнопок
            buttonKillsHimself.BackColor = Color.LimeGreen;
            buttonEatsHimself.BackColor = Color.OrangeRed;
        }

        private void buttonEatsHimself_Click(object sender, EventArgs e)
        {
            eatsHimself = true;
            killsHimself = false;

            // изменяет цвет кнопок
            buttonEatsHimself.BackColor = Color.LimeGreen;
            buttonKillsHimself.BackColor = Color.OrangeRed;
        }


        // включить/выключить музыку
        private void SoundTrackButton_Click(object sender, EventArgs e)
        {
            _useSoundTrack = !_useSoundTrack;
            SoundTrackButton.BackColor = (SoundTrackButton.BackColor == Color.Lime) ? Color.Red : Color.Lime;

            if (_useSoundTrack) soundTracks[musicID].PlayLooping();
            else soundTracks[musicID].Stop();
        }

        // сменить музыку
        private void musicNameButton_Click(object sender, EventArgs e)
        {
            soundTracks[musicID].Stop();

            if (musicID >= 0 && musicID < musicNames.Length - 1) musicID++;
            else if (musicID == musicNames.Length - 1) musicID = 0;

            // меняет музыку
            soundTracks[musicID].PlayLooping();
            SoundTrackButton.BackColor = Color.Lime;
            _useSoundTrack = true;
        }


        // закончить настройки
        private void buttonEndSettings_Click(object sender, EventArgs e)
        {
            // убрать лишнее
            this.Controls.Clear();

            // начать игру
            _startgame();

            // включить таймер
            timer.Start();

            // убрать кнопку окончания настроек
            this.Controls.Remove(buttonEndSettings);
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
