using QuanLyKho.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XAct;

namespace QuanLyKho.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        // We finish ALL here
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UintCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }


        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get => _TonKhoList; set { _TonKhoList = value; OnPropertyChanged(); } }



        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                LoginWindow loginWindow = new LoginWindow();
                if (p == null)
                    return;
                p.Hide();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if(loginVM.IsLogin)
                {
                    p.Show();
                    LoadTonKhoData();
                }
                else
                {
                    p.Close();
                }
            }
            );

            UintCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                UnitWindow wd = new UnitWindow();
                wd.ShowDialog();
            }
            );

            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SuplierWindow wd = new SuplierWindow();
                wd.ShowDialog();
            }
            );

            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerWindow wd = new CustomerWindow();
                wd.ShowDialog();
            }
            );

            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ObjectWindow wd = new ObjectWindow();
                wd.ShowDialog();
            }
            );

            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                InputWindow wd = new InputWindow();
                wd.ShowDialog();
            }
            );

            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                OutputWindow wd = new OutputWindow();
                wd.ShowDialog();
            }
            );

            
        }


        void LoadTonKhoData()
        {
            TonKhoList = new ObservableCollection<TonKho>();

            var sumInputList = from obj in DataProvider.Ins.DB.InputInfos
                               group obj by obj.IdObject into g
                               select new
                               {
                                   IdObject = g.Key,
                                   sumInput = g.Sum(x => x.Count)

                               };
            var sumOutputList = from obj in DataProvider.Ins.DB.OutputInfos
                                group obj by obj.IdObject into g
                                select new
                                {
                                    IdObject = g.Key,
                                    sumOutput = g.Sum(x => x.Count)
                                };
            var sumCount = from input in sumInputList
                           join output in sumOutputList
                           on input.IdObject equals output.IdObject
                           join obj in DataProvider.Ins.DB.Objects
                           on input.IdObject equals obj.Id
                           select new
                           { 
                               idObject = input.IdObject,
                               DisplayName = obj.DisplayName,
                               count = input.sumInput - output.sumOutput
                           };

            foreach(var items in sumCount)
            {
                TonKho tonkho = new TonKho();
                tonkho.Id = int.Parse(items.idObject);
                tonkho.Count = (int)items.count;
                tonkho.DisplayName = items.DisplayName;
                TonKhoList.Add(tonkho);
            }


        }

    }

}
