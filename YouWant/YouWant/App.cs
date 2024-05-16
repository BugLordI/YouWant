using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using YouWant.Language;
using YouWant.View;

namespace YouWant
{
    /// <summary>
    /// 程序入口，自行扩展，提供了：<br/>
    /// <see cref="setLanguage(string[])">语言设置</see><br/>
    /// <see cref="App_DispatcherUnhandledException">异常处理</see><br/>
    /// </summary>
    public class App : Application
    {
        private const string PRODUCT_NAME = "YOU_WANT";

        [STAThread]
        static void Main(string[] args)
        {
            setLanguage(args);
            bool ret;
            // 不允许多开程序
            Mutex mutex = new(true, PRODUCT_NAME, out ret);
            if (ret)
            {
                Application app = new();
                app.DispatcherUnhandledException += App_DispatcherUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += App_DispatcherUnhandledException;
                MainWindow mainWindow = new MainWindow();
                app.Run(mainWindow);
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(LanguageManager.Instance["LaunchFailed"], LanguageManager.Instance["Tip"], MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static void App_DispatcherUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(LanguageManager.Instance["UnexpectedErrorTip"]);
        }

        private static void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(LanguageManager.Instance["UnexpectedErrorTip"]);
        }

        static void setLanguage(string[] args)
        {
            var local = "--local:";
            foreach (var item in args)
            {
                if (item.Contains(local))
                {
                    var lan = item[local.Length..];
                    LanguageManager.Instance.ChangeLanguage(new CultureInfo(lan));
                    break;
                }
            }
        }
    }
}
