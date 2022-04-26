open System
open System.Windows.Forms
open System.IO
open System.Drawing

[<EntryPoint>]
let main argv =
    let form = new Form(Width = 450, Height = 300, Text = "Меню", Menu = new MainMenu(), BackColor = System.Drawing.Color.Azure)
    let button1 = new Button(Text = "Клац", Top = 50, Left = 125, Width = 150, Height = 140,
    BackColor = System.Drawing.Color.Ivory,
    Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    
    //1 Форма
    let form1 = new Form(Text = "Тест на мужика", Width = 450, Height = 250, BackColor = System.Drawing.Color.Azure)
    let label1 = new Label(Text = "Сколько в доте однозглазых героев?", AutoSize = true, Location = new System.Drawing.Point(60, 60),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    form1.Controls.Add(label1)

    let opForm1 EventsArgs = do form1.ShowDialog()
    button1.Click.Add opForm1
    form.Controls.Add(button1)
    let button2 = new Button(Text = "0", Top=125, Left = 50, Width = 100, Height = 50,BackColor = System.Drawing.Color.Ivory)
    let button3 = new Button(Text = "1", Top=125, Left = 150, Width = 100, Height = 50,BackColor = System.Drawing.Color.Ivory)
    let button4 = new Button(Text = "2", Top = 125, Left = 250, Width = 100, Height = 50,BackColor = System.Drawing.Color.Ivory)
    form1.Controls.Add(button2)
    form1.Controls.Add(button3)
    form1.Controls.Add(button4)

    //2 форма
    let wrong = new Form(Text= "Прекрати бить лес, немедленно", Width = 300, Height = 160, BackColor = System.Drawing.Color.Red)
    let labelWrong = new Label(Text = "Нет.",AutoSize = true, Location = new System.Drawing.Point(60, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    wrong.Controls.Add(labelWrong)
    //3 форма
    let right = new Form(Text="ООООООООО" , Width = 300, Height = 160, BackColor = System.Drawing.Color.LimeGreen)
    let labelRight = new Label(Text = "Правильно",AutoSize = true, Location = new System.Drawing.Point(50, 50),
    Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))))
    right.Controls.Add(labelRight)


    let opForm2 EventsArgs = do wrong.ShowDialog()
    let opForm3 EventsArgs = do right.ShowDialog()

    button2.Click.Add(opForm2)
    button3.Click.Add(opForm3)
    button4.Click.Add(opForm2)

    Application.Run(form)
    0
