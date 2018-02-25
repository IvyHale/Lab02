using Lab02.ModelView;
using System.Windows;

namespace Lab02.View
{
    /// <summary>
    /// Interaction logic for PersonEdit.xaml
    /// </summary>
    public partial class PersonEdit : Window
    {
        public PersonEdit()
        {
            InitializeComponent();
            DataContext = new PersonEditViewModel();
        }
        
    }
}
