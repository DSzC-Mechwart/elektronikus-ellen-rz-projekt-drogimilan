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
using System.Windows.Shapes;

namespace Projekt_1
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private StudentRepository studentRepository;

        public AdminWindow(StudentRepository repository)
        {
            InitializeComponent();
            studentRepository = repository;
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = studentRepository.GetAllStudents();
            StudentsDataGrid.ItemsSource = students;
            UpdateStatistics(students);
        }

        private void UpdateStatistics(List<Tanulo> students)
        {
            int dormitoryCount = studentRepository.CountDormitoryStudents();
            int debrecenCount = studentRepository.CountStudentsFromDebrecen();
            int commutingCount = studentRepository.CountCommutingStudents();

            DormitoryCountTextBlock.Text = $"Kollégista: {dormitoryCount}";
            DebrecenCountTextBlock.Text = $"Debreceni: {debrecenCount}";
            CommutingCountTextBlock.Text = $"Bejárós: {commutingCount}";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = (Tanulo)StudentsDataGrid.SelectedItem;
            if (selectedStudent != null)
            {
                var result = MessageBox.Show($"Biztosan törli {selectedStudent.Name} adatait?", "Törlés megerősítése", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    studentRepository.DeleteStudent(selectedStudent);
                    LoadStudents();
                }
            }
        }
    }
}