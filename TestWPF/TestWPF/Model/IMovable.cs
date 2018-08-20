using System.Windows;

namespace TestWPF.Model
{
    interface IMovable
    {
        FrameworkElement Parent { get; set; }
        double X { get; set; }
        double Y { get; set; }
    }
}
