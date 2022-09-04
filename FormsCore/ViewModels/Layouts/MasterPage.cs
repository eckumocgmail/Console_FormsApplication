
using System.Collections.Generic;

[EntityLabel("Страница пользователя")]
public class MasterPage : PageItem
{
    public Repetable Focusing = new Repetable();



    public FocusModel NowInFocus = new FocusModel();




    public SearchByCtrl Search { get; set; } = new SearchByCtrl();
    public Notifications Notifications { get; set; } = new Notifications();

    public Form InputForm { get; set; } = new Form(new TestAttributeInputClass());
    public ViewItem Page { get; set; }
    
  
    public Tree Navigation { get; set; } = new Tree() { 
        Item = new  NamedObject() { 
            Name = "Навигация"
        }
    };
    public NavBar NavBar { get; set; } = new NavBar()
    {
        ChildLinks = new List<ILink>() {
                new Link(){
                    Href = "/DevFace/Dev/DevHome",
                    Label = "Конструктор",
                    Icon = "settings",
                },
                new Link(){
                    Href = "/UserFace/User/UserHome",
                    Label = "Пользователь",
                    Icon = "home",
                },
                new Link(){
                    Href = "/Home/Index",
                    Label = "Домашняя",
                    Icon = "home",
                },


                new Link()
                {
                    Href = "/DevFace/Dev/DevHome",
                    Label = "Разработчик",
                    Icon = "settings",
                    Children = new List<ViewNode>(){
                        new Link(){
                            Href = "/DevFace/BusinessReports/Index",
                            Label = "Отчёты",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessDatasources/Index",
                            Label = "Источники данных",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessDatasets/Index",
                            Label = "Наборы данных",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessResources/Index",
                            Label = "Управляемые ресурсы",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessFunctions/Index",
                            Label = "Бизнес функции",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessProcesses/Index",
                            Label = "Бизнес процессы",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessLogics/Index",
                            Label = "Бизнеc правила",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/BusinessIndicators/Index",
                            Label = "Бизнес показатели",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/MessageProtocols/Index",
                            Label = "Модели потоков данных",
                            Icon = "settings",
                        },
                        new Link(){
                            Href = "/DevFace/MessageAttributes/Index",
                            Label = "Атрибуты сообщений",
                            Icon = "settings"
                        },
                    }
                },

                new Link(){
                    Href = "/UserFace/User/UserHome",
                    Label = "Личный кабинет",
                    Icon = "person",
                    Children = new List<ViewNode>(){
                        new Link(){
                            Href = "/UserFace/User/Messages",
                            Label = "Сообщения",
                            Icon = "message"
                        },
                        new Link(){
                            Href = "/UserFace/Settings/Edit",
                            Label = "Настройки",
                            Icon = "settings"
                        },
                        new Link(){
                            Href = "/UserFace/People/Index",
                            Label = "Сотрудники",
                            Icon = "people"
                        },
                        new Link(){
                            Href = "/UserFace/Groups/Index",
                            Label = "Группы",
                            Icon = "people"
                        },
                        new Link(){
                            Href = "/Account/Logout",
                            Label = "Выход",
                            Icon = "logout"
                        }
                    }
                },
                new Link(){
                    Href = "/About",
                    Label = "Информация",
                    Icon = "person",
                    Children = new List<ViewNode>(){                      
                        new Link(){
                            Href = "/About/SeparationOfResponsibilities",
                            Label = "Функциональная модель",
                            Icon = "help"
                        },
                        new Link(){
                            Href = "/About/PrivacyPolicy",
                            Label = "Политика конфиденциальности",
                            Icon = "help"
                        },
                        new Link(){
                            Href = "/About/ContactInformation",
                            Label = "Контактная информация",
                            Icon = "help"
                        },
                    }
                },
        }
    };
    public Router Router { get; set; } = new Router()
    {
         
    };



    public MasterPage()
    {
        Init();
        WasChanged();
    }

    public Button Ok { get; set; } = new Button() { Label = "OK" };
    public Button Cancel { get; set; } = new Button() { Label = "Cancel" };

    public override void Init()
    {
        this.Chapter = "Главная страница";
        //this.Navigation.Bind(this.Router);
        //base.Init();
        this.Append(this.NavBar);
        this.Append(this.Search);
        this.Append(this.Navigation);
        InputForm.Visible = true;
        //this.Append(this.InputForm);
        NowInFocus.EnableChangeSupport = true;
 
        //this.Router.Navigate("./index");

        //this.Append(this.Page = this.Router.Active);

    }

}
 