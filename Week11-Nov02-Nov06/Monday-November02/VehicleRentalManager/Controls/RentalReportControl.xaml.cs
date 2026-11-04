using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VehicleRentalManager.Models;
using VehicleRentalManager.ViewModels;

namespace VehicleRentalManager.Controls
{
    /// <summary>
    /// Interaction logic for RentalReportControl.xaml
    /// </summary>
    public partial class RentalReportControl : UserControl
    {
        public RentalReportControl(VehicleManager manager)
        {
            InitializeComponent();

            DataContext = new RentalReportViewModel(manager);

        }



        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the ViewModel currently serving as
            // this control's DataContext.
            RentalReportViewModel? viewModel = DataContext as RentalReportViewModel;

            if (viewModel == null)
            {
                return;
            }

            // Ask the ViewModel to create and save the report.
            string filePath = viewModel.SaveHtmlReport();

            MessageBox.Show(
                $"Report successfully generated.\n\n{filePath}",
                "Report Generated",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            // Ask Windows to open the HTML file using
            // the user's default browser.
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }

    }
}
