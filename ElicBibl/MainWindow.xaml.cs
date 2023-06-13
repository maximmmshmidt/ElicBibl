using ElicBibl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;

namespace ElicBibl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Core db = new Core();
        List<Book> arrayProduct;
        public MainWindow()
        {
            InitializeComponent();
            arrayProduct = db.context.Book.ToList();
            Soderj.ItemsSource = arrayProduct;
            NumBook.ItemsSource = arrayProduct;

        }
        private List<Book> GetRows_Author()
        {
            arrayProduct = db.context.Book.ToList();
            string searchData = Author.Text.ToUpper();
            if (!String.IsNullOrEmpty(Author.Text))
            {
                arrayProduct = arrayProduct.Where(x => x.Author.ToUpper().Contains(searchData)).ToList();
            }
            return arrayProduct;
        }

        private List<Book> GetRows_nameBook()
        {
             arrayProduct = db.context.Book.ToList();
            string searchData = NameBook.Text.ToUpper();
            if (!String.IsNullOrEmpty(NameBook.Text))
            {
                arrayProduct = arrayProduct.Where(x => x.Name.ToUpper().Contains(searchData)).ToList();
            }
            return arrayProduct;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Soderj.ItemsSource = GetRows_nameBook();
        }

        private void Author_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Soderj.ItemsSource = GetRows_Author();
            NumBook.ItemsSource = GetRows_Author();
        }

        private void NameBook_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Soderj.ItemsSource = GetRows_nameBook();
            NumBook.ItemsSource = GetRows_nameBook();
        }

        private void Exels(object sender, RoutedEventArgs e)
        {
            List<Book> numberBookGiven = arrayProduct;
            /*создаем файл Excel*/

            var aplication = new Excel.Application
            {
                Visible = true,

                /*количество листов*/

                SheetsInNewWorkbook = 1
            };

            /*добавляем рабочую книгу*/

            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);

            /*создаем лист*/

            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.Name = "BookForGiven"; //имя листа нужно вводить латинскими буквами

            /*заголовки вывод в Excel (в первую строку)*/

            worksheet.Cells[1][1] = "Название книги";
            worksheet.Cells[2][1] = "Автор";
            worksheet.Cells[3][1] = "Кол Книг";
            worksheet.Cells[4][1] = "Краткое описание";

            worksheet.Cells[4][1].font.bold = true;
            worksheet.Cells[3][1].font.bold = true;
            worksheet.Cells[2][1].font.bold = true;
            worksheet.Cells[1][1].font.bold = true;

            /*вывод данных из массива в Excel*/



            int rowIndex = 2;

            foreach (var item in numberBookGiven)
            {
                worksheet.Cells[1][rowIndex] = item.Name;
                worksheet.Cells[2][rowIndex] = item.Author;
                worksheet.Cells[3][rowIndex] = item.NumberBook;
                worksheet.Cells[4][rowIndex] = item.Summary;
                worksheet.Columns.AutoFit();
                rowIndex++;
            }
        }
    }
}
