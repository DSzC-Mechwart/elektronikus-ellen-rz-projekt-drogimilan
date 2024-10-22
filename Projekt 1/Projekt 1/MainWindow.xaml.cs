using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentRepository studentRepository;
        private int logNumberCounter;

        public MainWindow()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
            logNumberCounter = studentRepository.GetAllStudents().Count(s => s.EnrollmentDate < new DateTime(DateTime.Now.Year, 9, 1));
        }

        private void IsDormitoryCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            DormitoryLabel.Visibility = Visibility.Visible;
            DormitoryTextBox.Visibility = Visibility.Visible;
        }

        private void IsDormitoryCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            DormitoryLabel.Visibility = Visibility.Collapsed;
            DormitoryTextBox.Visibility = Visibility.Collapsed;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var student = new Tanulo
            {
                Name = NameTextBox.Text,
                Birthplace = BirthplaceTextBox.Text,
                BirthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue,
                MotherName = MotherNameTextBox.Text,
                Address = AddressTextBox.Text,
                EnrollmentDate = EnrollmentDatePicker.SelectedDate ?? DateTime.MinValue,
                Major = MajorTextBox.Text,
                Class = ClassTextBox.Text,
                IsDormitory = IsDormitoryCheckbox.IsChecked == true,
                Dormitory = IsDormitoryCheckbox.IsChecked == true ? DormitoryTextBox.Text : null,
                LogNumber = ++logNumberCounter,
                RegisterNumber = $"{logNumberCounter}/{EnrollmentDatePicker.SelectedDate?.Year}"
            };

            studentRepository.SaveStudent(student);
            StatusTextBlock.Text = "Tanuló adatai mentve!";
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(studentRepository);
            adminWindow.ShowDialog();
        }
    }
}
