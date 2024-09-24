using static SqlDatabaseUpdater.Sql.SqlFunctions;
namespace SqlDatabaseUpdater
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
           
        }


        private async void TagInput_Completed(object sender, EventArgs e)
        {
            string tag = ((Entry)sender).Text;
            
            var newtag = tag.Replace(" ", ",");

           await  update(newtag);

            Sucess.Text = "Update Sucessfully";






        }
    }

}
