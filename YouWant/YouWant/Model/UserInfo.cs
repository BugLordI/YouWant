using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YouWant.Model
{
    /// <summary>
    /// 这是示例代码
    /// </summary>
    public class UserInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? userName;
        private int? age;
        private string? address;

        public String? UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        public int? Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public String? Address {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
    }
}
