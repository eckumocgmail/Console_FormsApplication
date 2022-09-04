using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
[EntityLabel("Авторизация пользователя")]
public class LoginLog:  
{
    [InputEmail("Электронный адрес задан некорректно")]
    [Label("Электронный адрес")]
    [NotNullNotEmpty("Не указан электронный адрес")]
    [Icon("email")]
    [UniqValidation("Этот адрес электронной почты уже зарегистрирован")]
    [JsonProperty("Email")]
    public string Email { get; set; }


    [Label("Пароль")]
    [NotNullNotEmpty]
    [InputPassword()]
    [NotMapped]

    [JsonProperty("Password")]
    public string Password { get; set; }

    public LoginRequest()
    {
    }

    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}

 */