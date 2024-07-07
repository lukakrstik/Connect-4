# Connect4
Проектна задача по Визуелно Програмирање-Connect 4




Опис на апликацијата
Апликацијата Connect 4 Windows Forms е дигитална верзија на класичната игра Connect 4, наменета за двајца играчи. Играта се игра на мрежа со 7 колони и 6 реда, каде играчите наизменично поставуваат обоени дискови од врвот во колоните. Победник на играта е оној играч што прв ќе формира хоризонтална, вертикална или дијагонална линија од четири дискови со иста боја.

Изглед на апликацијата

![image](https://github.com/lukakrstik/Connect-4/assets/153298627/bd7f0c73-f45d-4470-a764-b7b678fbe1e8) 
![image](https://github.com/lukakrstik/Connect-4/assets/153298627/c888c790-4b8c-490b-a2fe-b419c5d53634)




 
Формата содржи:

•	Мрежа 7х6 на која се изведува играта,
•	Копче “Start Game” со кое што се започнува играта,
•	Menu Strip кој содржи копчиња за одбирање на боја на дисковите на двата играчи, како и копче за избор на почетен играч.
Податоците на формата се серијализирани и можат да бидат зачувани при завршување со играта.

Класи и нивните функционалности

Апликацијата содржи 3 позначајни класи:

•	Ball.cs – ги претставува дисковите кои се користат за играње и дефинира својства и методи поврзани со дисковите на играта, како што се позицијата и сопственоста на играчот.

•	Scene.cs - Управува со таблата за игра и со цртањето на дисковите. 

•	Form1.cs - Управува со таблата за игра, ги обработува движењата на играчите, ги проверува условите за победа и ја ресетира таблата по победата. Вклучува методи за иницијализирање на таблата, справување со кликнувања на копчињата и проверка на условите за победа.


Имплементирани методи во проектот

•	AddBall(Ball ball): Методот AddBall додава диск на сцената со додавање на наведениот објект Ball во списокот со топки. Овој метод управува со збирката на парчиња игра што треба да се изведат на таблата за игра, осигурувајќи дека секој потег е визуелно претставен.
```C#
public void addBall(Point p)
{
    
    for (int i = 0; i < 6; i++)
    {
        if (played[i, p.X / 100] == 0)
        {
            p.Y = i * 100; 
        }
    }
    if (p.Y < 700)
    {
        if (currentPlayer == 1 && played[p.Y / 100, p.X / 100] == 0)
        {
            Ball ball = new Ball(p, player1color);
            balls.Add(ball);
            played[p.Y / 100, p.X / 100] = 1;
            if(WinCheck(currentPlayer))
            {
                Winner = "Winner: Player " + currentPlayer;
            }
            
            currentPlayer = 2;
            
        }
        else if (currentPlayer == 2 && played[p.Y / 100, p.X / 100] == 0)
        {
            Ball ball = new Ball(p, player2color);
            balls.Add(ball);
            played[p.Y / 100, p.X / 100] = 2;
            if (WinCheck(currentPlayer))
            {
                Winner = "Winner: Player " + currentPlayer;
            }
            currentPlayer = 1;
            
        }

    }
}
```

•	Draw(Graphics g): Методот Draw ги црта парчињата од играта на формуларот користејќи графички објект. Се повторува низ списокот со топки и ја црта секоја на одредената позиција, користејќи различни бои за различни играчи. Овој метод осигурува дека таблата за игра е визуелно ажурирана за да ја одрази моменталната состојба на играта, обезбедувајќи им повратни информации на играчите за нивните потези.

```C#
public void Draw(Graphics g)
{
    
    int X = (center.X / 100) * 100;
    int Y = (center.Y / 100) * 100;
    
       Brush b = new SolidBrush(color);
       g.FillEllipse(b, X, Y+50, 2 * radius, 2 * radius);
       b.Dispose();
       Color shadeColor = ControlPaint.Dark(color);
       Pen p = new Pen(new SolidBrush(shadeColor), 8);
       g.DrawEllipse(p, X+4, Y+54,(float) 1.82 * radius, (float) 1.82 * radius); 
       p.Dispose();


}
```
•	WinCheck(int row, int column): Методот WinCheck проверува дали тековниот потег резултирал со победа. Потврдува дали има четири последователни дискови од истиот играч хоризонтално, вертикално или дијагонално со повторување низ потенцијалните победнички позиции почнувајќи од позицијата на тековниот диск. Ако се најдат 4 поврзани дискови, се враќа точно, во спротивно, се продолжува со играта. Доколку табелата е исполнета со дискови без да се најде поврзување, се враќа резултат "Нерешено". Овој метод е од суштинско значење за одредување на исходот на играта по секој потег.

```C#
 private bool WinCheck(int currplayer) {

     for (int i = 0; i < played.GetLength(0); i++)
     {
         for (int j = 0; j <= played.GetLength(1)-4; j++)
         {
             if (played[i, j] == currplayer &&
             played[i, j + 1] == currplayer &&
             played[i, j + 2] == currplayer &&
             played[i, j + 3] == currplayer)
             {
                 return true;
             }
         }
     }
     for (int i = 0; i <= played.GetLength(0)-4; i++)
     {
         for (int j = 0; j < played.GetLength(1); j++)
         {
             if (played[i, j] == currplayer &&
             played[i + 1, j ] == currplayer &&
             played[i + 2, j ] == currplayer &&
             played[i + 3, j ] == currplayer)
             {
                 return true;
             }
         }
     }

     for (int i = 0; i <= played.GetLength(0) - 4; i++)
     {
         for (int j = 0; j <= played.GetLength(1)-4; j++)
         {
             if (played[i, j] == currplayer &&
             played[i + 1, j + 1] == currplayer &&
             played[i + 2, j + 2] == currplayer &&
             played[i + 3, j + 3] == currplayer)
             {
                 return true;
             }
         }
     }
     for (int i = 3; i < played.GetLength(0); i++)
     {
         for (int j = 0; j <= played.GetLength(1) - 4; j++)
         {
             if (played[i, j] == currplayer &&
             played[i - 1, j + 1] == currplayer &&
             played[i - 2, j + 2] == currplayer &&
             played[i - 3, j + 3] == currplayer)
             {
                 return true;
             }
         }
     }

     bool tableFull = true;
     for (int i = 0; i < played.GetLength(0); i++)
     {
         for (int j = 0; j < played.GetLength(1); j++)
         {
             if (played[i,j] == 0)
             {
                 tableFull = false;
             }
         }
     }
     if (tableFull)
     {
         Winner = "Draw";
     }
     return false;
 }
```

•	ShowWinner(): Методот ShowWinner е одговорен за известување на играчите кога играта ќе заврши со победа. Кога методот WinCheck детектира победнички услов, го активира методот ShowWinner, пренесувајќи го името на победничкиот играч како аргумент. Внатре во методот ShowWinner, се прикажува поле за пораки со честитка која го содржи името на победникот. Ова поле за пораки служи како визуелно известување за двајцата играчи, јасно означувајќи го крајот на играта и победникот. Откако ќе се отфрли полето за пораки од играчите, методот ShowWinner ја ресетира таблата за игра. Ова осигурува дека таблата за игра е исчистена, враќајќи ја во нејзината почетна состојба и дозволувајќи им на играчите да започнат нова игра без потреба од рестартирање на апликацијата.

```C#
private void ShowWinner()
{
    DialogResult result = MessageBox.Show(Scene.Winner,"Congratulations!!!");
    if (result == DialogResult.OK)
    {
        button1.Visible = true;
        label1.Visible = true;
        Scene = Scene = new Scene(player1color, player2color, startingPlayer);
        gameStarted = false;
        Invalidate();
    }
}
```
