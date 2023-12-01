﻿using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using XSystem.Security.Cryptography;

namespace QuanLyKho.ViewModel
{
    // We finish ALL here
    internal class LoginViewModel : BaseViewModel
    {
        
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }
        private string _UserName;
        private string _Password;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public bool IsLogin { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            UserName = "";
            Password = "";           
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{ Login(p); } );
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; } );

        }

        void Login(Window p)
        {
            if(p==null)
                return;
            string passEncode = MD5Hash(Base64Encode(Password));
            
            var account = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == passEncode).Count();
            if(account > 0)
            {
                IsLogin = true;
                p.Close();

            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);    
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

    }
    
}
