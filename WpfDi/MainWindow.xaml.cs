using System;
using System.Windows;

namespace WpfDi;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly TestClass _testClass;

    public MainWindow(TestClass testClass)
    {
        InitializeComponent();
        _testClass = testClass;

        Activated += MainWindow_Activated;
    }

    private void MainWindow_Activated(object sender, EventArgs e)
    {
        lblMessage.Content = _testClass.Message;
    }
}