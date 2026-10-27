using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgrammaticControlsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // InitializeComponent() loads the XAML associated with this window.
            //
            // Normally, our controls would be declared in MainWindow.xaml.
            // In this example, however, we are going to create most of the
            // interface ourselves using C#.
            InitializeComponent();


            // ============================================================
            // STEP 1: CREATE THE MAIN GRID
            // ============================================================

            // A Grid is a WPF layout control.
            //
            // Just like we can write:
            //
            // <Grid>
            // </Grid>
            //
            // in XAML, we can create the same Grid as a C# object.
            Grid grid = new Grid();


            // Give the Grid some space around its edges.
            //
            // Equivalent XAML:
            //
            // <Grid Margin="20">
            grid.Margin = new Thickness(20);


            // ============================================================
            // STEP 2: CREATE ROWS FOR THE GRID
            // ============================================================

            // Our interface will contain several controls, so we need
            // several rows.
            //
            // We are creating five rows:
            //
            // Row 0 -> Heading
            // Row 1 -> Equipment Name label
            // Row 2 -> Equipment Name TextBox
            // Row 3 -> Category ComboBox
            // Row 4 -> Buttons


            // Create the first row.
            RowDefinition headingRow = new RowDefinition();

            // GridLength.Auto means:
            // "Make this row only as tall as its content needs."
            headingRow.Height = GridLength.Auto;

            // Add the row to the Grid.
            grid.RowDefinitions.Add(headingRow);


            // Create another row.
            RowDefinition labelRow = new RowDefinition();
            labelRow.Height = GridLength.Auto;
            grid.RowDefinitions.Add(labelRow);


            // Create another row.
            RowDefinition textBoxRow = new RowDefinition();
            textBoxRow.Height = GridLength.Auto;
            grid.RowDefinitions.Add(textBoxRow);


            // Create another row.
            RowDefinition categoryRow = new RowDefinition();
            categoryRow.Height = GridLength.Auto;
            grid.RowDefinitions.Add(categoryRow);


            // Create the final row.
            RowDefinition buttonRow = new RowDefinition();

            // The * means:
            // "Use the remaining available space."
            buttonRow.Height = new GridLength(
                1,
                GridUnitType.Star);

            grid.RowDefinitions.Add(buttonRow);


            // ============================================================
            // STEP 3: CREATE THE HEADING
            // ============================================================

            // Create a TextBlock object.
            //
            // Equivalent XAML:
            //
            // <TextBlock />
            TextBlock heading = new TextBlock();


            // Set properties on the TextBlock.
            //
            // Equivalent XAML:
            //
            // <TextBlock
            //     Text="Campus Equipment Center"
            //     FontSize="30"
            //     FontWeight="Bold" />
            heading.Text = "Campus Equipment Center";
            heading.FontSize = 30;
            heading.FontWeight = FontWeights.Bold;


            // Add some space underneath the heading.
            heading.Margin = new Thickness(0, 0, 0, 20);


            // Place the heading in Grid row 0.
            //
            // Equivalent XAML:
            //
            // Grid.Row="0"
            Grid.SetRow(heading, 0);


            // IMPORTANT:
            //
            // Creating the TextBlock does NOT automatically display it.
            //
            // We must add it to the Grid's Children collection.
            grid.Children.Add(heading);


            // ============================================================
            // STEP 4: CREATE A LABEL
            // ============================================================

            TextBlock equipmentNameLabel = new TextBlock();

            equipmentNameLabel.Text = "Equipment Name:";
            equipmentNameLabel.FontSize = 16;
            equipmentNameLabel.FontWeight = FontWeights.SemiBold;

            equipmentNameLabel.Margin =
                new Thickness(0, 5, 0, 5);


            // Put the label in row 1.
            Grid.SetRow(equipmentNameLabel, 1);


            // Add the label to the Grid.
            grid.Children.Add(equipmentNameLabel);


            // ============================================================
            // STEP 5: CREATE A TEXTBOX
            // ============================================================

            // Create a TextBox where the user can enter an equipment name.
            TextBox equipmentNameTextBox = new TextBox();


            // Set some properties.
            equipmentNameTextBox.Width = 300;
            equipmentNameTextBox.Height = 35;


            // Align the TextBox to the left instead of allowing it
            // to stretch across the entire Grid.
            equipmentNameTextBox.HorizontalAlignment =
                HorizontalAlignment.Left;


            equipmentNameTextBox.Margin =
                new Thickness(0, 0, 0, 15);


            // Put the TextBox in row 2.
            Grid.SetRow(equipmentNameTextBox, 2);


            // Add it to the Grid.
            grid.Children.Add(equipmentNameTextBox);


            // ============================================================
            // STEP 6: CREATE A COMBOBOX
            // ============================================================

            ComboBox categoryComboBox = new ComboBox();

            categoryComboBox.Width = 300;
            categoryComboBox.Height = 35;

            categoryComboBox.HorizontalAlignment =
                HorizontalAlignment.Left;

            categoryComboBox.Margin =
                new Thickness(0, 0, 0, 20);


            // Add items to the ComboBox.
            //
            // The Items collection stores the items that the
            // ComboBox can display.
            categoryComboBox.Items.Add("Laptop");
            categoryComboBox.Items.Add("Camera");
            categoryComboBox.Items.Add("Projector");
            categoryComboBox.Items.Add("Microphone");
            categoryComboBox.Items.Add("Tablet");


            // Put the ComboBox in row 3.
            Grid.SetRow(categoryComboBox, 3);


            // Add it to the Grid.
            grid.Children.Add(categoryComboBox);


            // ============================================================
            // STEP 7: CREATE A STACKPANEL FOR THE BUTTONS
            // ============================================================

            // We want our buttons to appear next to each other.
            //
            // A horizontal StackPanel is convenient for this.
            StackPanel buttonPanel = new StackPanel();


            // Children will be arranged from left to right.
            buttonPanel.Orientation = Orientation.Horizontal;


            // Put the StackPanel in row 4.
            Grid.SetRow(buttonPanel, 4);


            // Add the StackPanel to the Grid.
            grid.Children.Add(buttonPanel);


            // ============================================================
            // STEP 8: CREATE THE ADD BUTTON
            // ============================================================

            Button addButton = new Button();


            // Content controls such as Button use Content
            // to determine what appears inside them.
            addButton.Content = "Add Equipment";


            addButton.Height = 50;
            addButton.Width = 150;


            // Add some space between this button and the next one.
            addButton.Margin =
                new Thickness(0, 0, 10, 0);


            // Add the Button to the StackPanel.
            //
            // Notice that we do NOT add it directly to the Grid.
            //
            // Our visual hierarchy is:
            //
            // Window
            //   └── Grid
            //         └── StackPanel
            //               └── Button
            buttonPanel.Children.Add(addButton);


            // ============================================================
            // STEP 9: CREATE A CLEAR BUTTON
            // ============================================================

            Button clearButton = new Button();

            clearButton.Content = "Clear";
            clearButton.Height = 50;
            clearButton.Width = 100;


            // Add it to the same StackPanel.
            buttonPanel.Children.Add(clearButton);


            // ============================================================
            // STEP 10: CONNECT EVENTS
            // ============================================================

            // Controls created programmatically can use events exactly
            // like controls created in XAML.
            //
            // Here we attach a Click event handler to the Add button.
            addButton.Click += (sender, e) =>
            {
                // Read the text entered into the TextBox.
                string equipmentName = equipmentNameTextBox.Text;


                // Read the selected category.
                string? category =
                    categoryComboBox.SelectedItem?.ToString();


                // Check that the user entered an equipment name.
                if (string.IsNullOrWhiteSpace(equipmentName))
                {
                    MessageBox.Show(
                        "Please enter an equipment name.");

                    return;
                }


                // Check that a category was selected.
                if (category == null)
                {
                    MessageBox.Show(
                        "Please select an equipment category.");

                    return;
                }


                // Display the information entered by the user.
                MessageBox.Show(
                    $"Equipment: {equipmentName}\n" +
                    $"Category: {category}");
            };


            // The Clear button will clear the controls.
            clearButton.Click += (sender, e) =>
            {
                equipmentNameTextBox.Clear();

                categoryComboBox.SelectedIndex = -1;
            };


            // ============================================================
            // STEP 11: DISPLAY THE GRID IN THE WINDOW
            // ============================================================

            // This is one of the most important lines in the example.
            //
            // We created the Grid and all of its child controls in memory.
            // Now we make the Grid the content of the Window.
            //
            // The visual tree now looks approximately like this:
            //
            // MainWindow
            //      |
            //      +-- Grid
            //           |
            //           +-- TextBlock (Heading)
            //           |
            //           +-- TextBlock (Equipment Name Label)
            //           |
            //           +-- TextBox
            //           |
            //           +-- ComboBox
            //           |
            //           +-- StackPanel
            //                  |
            //                  +-- Add Equipment Button
            //                  |
            //                  +-- Clear Button
            //
            Content = grid;
        }
    }
}