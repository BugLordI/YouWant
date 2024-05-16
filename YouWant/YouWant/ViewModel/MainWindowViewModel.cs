using YouWant.Model;

namespace YouWant.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        // 示例
        private UserInfo? user;

        public MainWindowViewModel()
        {
            // 示例
            user = new()
            {
                UserName = "张三",
                Address = "江苏南京",
                Age = 22,
            };
        }

        // 示例
        public UserInfo? User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
    }
}
