# ***Описание репозитория*** :book:
Здесь будет реализовано консольное приложение на C#, с помощью которого можно играть в такую игру, как **шашки-рэндзю**.
Данная работа является реализацией лабораторной работы по дисциплине **"Технологии разработки современных программных комплексов"**

Авторы - *Денис Степаниденко* , *Пак Матвей* :sparkles:

# ***Архитектура*** :diamond_shape_with_a_dot_inside:

Сделано два уровня - *Presentation Layer* и *Business Layer* (далее будет редактироваться) :soon:
![image](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/assets/110686828/9655500f-41b2-45aa-bd07-1760d16ce888)


# ***Описание классов*** :computer:
## *[public abstract class Game](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/Game.cs)* :white_check_mark:
### *Методы*
1) *public abstract void Start()*. Метод, в котором реализована сама логика игры. Так как все игры имеют как минимум общий метод, которые запускает саму игру, то сделать такой уровень абстракции довольно неплохая идея.
## *[public class CheckersRenju : Game](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CheckersRenju.cs)* :white_check_mark:
### *Поля*
1) ***private Dictionary<int, string> _players = new Dictionary<int, string>()***. Словарь, где ключ - 1 или 2, которому сопоставляется имя игрока(1 - играет чёрными шашками, 2- играет белыми шашками).
2) ***public const int DeskSize = (int) CharactericticsOfTheGame.DeskSize***. Размер доски.
3) ***public const int WinningRowSize = (int) CharactericticsOfTheGame.WinningRowSize***. Количество подряд идущих шашек для победы
4) ***private Desk _desk = new Desk(DeskSize)***. Объект класса Desk, которое эквивалентно шахматной доске для игры
5) ***public int CurrentMove = 1***. Текущий ход игрока(1 - ходит игрок с чёрными шашками, 2 - ходит игрок с белыми шашками).
### *Методы*
1) ***public override void Start()***. Метод, в котором прописана логика самой игры, порядок вызова методов других классов.
2) ***public CheckersRenju()***. Конструктор данного класса.
## *[public class Check](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/Check.cs)* :white_check_mark:
### *Методы*
1) ***public static void CheckName(string s)***. Метод, в котором идёт проверка имени пользователя на корректность(имя не может быть пустым).
2) ***public static void CheckMove(Desk desk, string answerX, string answerY)***. Метод, в котором проверяет текущий ход игрока на корректность (проверяется пара чисел x,y).
3) ***public static void CheckCoord(int x, int y, Desk desk)***. Метод, в котором проверятся текущая координата, а именно что на этой координате не стоит ни чья фишка
4) ***public static bool CheckDraw(Desk desk)***. Метод, в котором идёт проверка на ничью.
5) ***public static bool CheckWinner(int currentMove, int xNew, int yNew, Desk desk)***. Метод в котором идёт проверка на победителя
6) ***public static void CheckChoiceGetOrLoad(string s)***. Метод, в котором проверяет правильность ввода данных пользователем для сохранения или загрузки игры.
7) ***public static void CheckLeaderBord(string answer)***. Метод, в котором проверяет правильность ввода данных пользователем для показа LeaderBoard.
## *[public enum CharactericticsOfTheGame](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CharactericticsOfTheGame.cs)* :white_check_mark:
### *Константы*
1) ***DeskSize = 15*** - размер поля для игры
2) ***WinningRowSize = 5*** - то сколько нужно подряд собрать шашек, чтобы победить
3) ***X = 1*** - символ, который используется для игрока, которые играет чёрными шашками
4) ***Y = 2*** - символ, который используется для игрока, который играет белыми шашками
## *[public class ExceptionWithMove : Exception](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
Данный класс нужен для создания кастомного Exception, который мы обрабатываем, когда игрок сделал неккоректный ход
## *[public class ExceptionWithSaveGame : Exception](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
Данный класс нужен для создания кастомного Exception, который мы обрабатываем, когда  файл с сохранением - пустой
## *[public class ExceptionWithLeaderBord : Exception](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
Данный класс нужен для создания кастомного Exception, который мы обрабатываем, когда файл с leaderBoard'ом - пустой
## *[public class ExceptionWithAnswerFromLeaderBord : Exception](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
Данный класс нужен для создания кастомного Exception, который мы обрабатываем, пользователь ввёл неккоретные данные при выборе - показаывать ли leaderBoard или же нет
## *[public class DAO](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
### *Поля*
1) ***private const string PathToSave***. Поле, которое содержит путь к файлу с сохранениями.
2) ***private const string PathToLeaderBord***. Поле, которое содержит путь к файлу с LeaderBord'ом.
### *Методы*
1) ***public static void LoadGame(Dictionary<int, string> players, ref int currentMove, Desk desk)***. Метод, в котором происходит загрузка последнего сохранения в игре.
2) ***public static void SaveGame(Dictionary<int, string> players, int currentMove, Desk desk)***. Метод, в котором происходит сохранение текущего состояния игры в файл.
3) ***public static string GetLeaderBord()***. Метод, который читает данные из файла с LeaderBoard'ом.
4) ***public static void UpdateLeaderBord(string winnerName, string looserName, bool winnerExists)***. Метод, в котором происходит обновления файла с LeaderBoard'ом.
## *[public class Desk](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
### *Поля*
1) ***private int _filledCount = 0***. Данное поле отвечает за количество заполненных ячеек на поле игры(нужно для подсчёты быстрого ничьи).
2) ***private string[,] _matrix***. Сама матрица, которая эквивалентна доске в шашках
### *Методы*
1) ***public Desk(int size)***. Конструктор данного класса.
2) ***public void SetMatrix(string[,] matrix)***. Set метод для поля matrix
3) ***public void SetFilledCount(int filledCount)***. Set метод для поля _filledCount
4) ***public int GetFilledCount()***. Get метод для поля _filledCount
5) ***public string[,] GetMatrix()***. Get метод для поля matrix
6) ***public string Show()***. Метод, который выводит поле игры на экран в человеко-читаемом формате.
7) ***public void Update(int currentMove, int x, int y)***. Метод, который обновляет текущее поле по заданным координатам.
8) ***public List<string> GetDiagonal(int xNew, int yNew, int xModifyer, int yModifyer)***. Метод, который выдает диагонали которые проходят через заданную точку.
## *[public class Input](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
### *Методы*
1) ***public static void GetName(out string name1, out string name2)***. Метод, который уведомляет пользователей ввести свои никнеймы.
2) ***public static void GetColor(Dictionary<int, string> players, string name1, string name2)***. Метод, который уведомляет пользователей, что началось распределение цветов шашек.
3) ***public static void GetNewOrLoad(out int choice)***. Метод, который уведомляет пользователей о начале игры и предлагает выбор - выбрать сохранённую игры или начать новую.
4) ***public static void GetMove(out int x, out int y, int currentMove, Dictionary<int, string> players, Desk desk)***. Метод, который уведомляет пользователей сделать текущий ход.
5) ***public static void ShowBord(out int n)***. Метод, который уведомляет пользователей о том, хотят ли они увидеть LeaderBoard
## *[public class Output](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
### *Методы*
1) ***public static void ShowDesk(Desk desk)***. Метод, который выводит поле на экран.
2) ***public static void ShowRole(Dictionary<int, string> players)***. Метод, который выводит игрокам их цвета шашек после распределения.
3) ***public static void ShowWinner(int currentMove, Dictionary<int, string> players)***. Метод, который выводит сообщение о победителе.
4) ***public static void ShowDraw()***. Метод, который выводит сообщение о ничье.
5) ***public static void ShowLeaderBord()***. Метод, который выводит LeaderBoard.
## *[public class Player : IComparable](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
Данный класс нужен лишь для сортировки игроков в LeaderBoard по убыванию побед.
### *Поля*
1) ***private string _name***. Имя игрока.
2) ***private int _victories***. Количество побед.
3) ***private int _countOfGame***. Количество всего игр.
### *Методы*
1) ***public int GetVictorice()***. Get метод для поля _victories.
2) ***public Player(string name, int victories, int countOfGame)***. Констурктор данного класса.
3) ***public override string ToString()***. Метод, для вывода состояния объекта в текстовом виде.
4) ***public int CompareTo(object o)***. Метод, в котором описана логика сравнения игроков, так чтобы они убывали по количество побед.
## *[internal class Program](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
Класс, в котором создаёт объект класса CheckersRenju и вызывается метод Start()
## *[public class RoleRandomizer](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
### *Методы*
1) ***public static void GetRole(Dictionary<int, string> players, string name1, string name2)***. Метод, в котором рандомно распределяются цвета шашек игроков.
## *[public class Utilities](https://github.com/DenisStepanidenko/renju-checkers-chapkin-lab/blob/master/CustomException.cs)* :white_check_mark:
### *Методы*
1) ***public static void UpdateCurrentMove(ref int currentMove)***. Метод, который обновляет текущий ход( переменная currentMove всегда либо 1, либо 2).
2) ***public static List<string> GetDeskRows(string[,] matrix)***. Метод, который возвращает все строки поля игры( нужна для записи игры в файл).

