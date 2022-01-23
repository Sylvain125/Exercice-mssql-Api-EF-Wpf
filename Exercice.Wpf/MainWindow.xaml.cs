using AutoMapper;
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
using Exercice.Model;
using System.Collections.ObjectModel;
using Exercice.Dto;
using System.Text.RegularExpressions;

namespace Exercice.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMapper _mapper = ((App)Application.Current).Mapper;

        public MonClient _client = new MonClient();

        public UserInfoList UsersList { get; set; } = new UserInfoList();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = UsersList;
        }

        private async void Button_ShowId(object sender, RoutedEventArgs e)
        {
            try
            {
                string idShow = IdShow.Text;
                var maRequeteParId = await _client.GetById(idShow);

                AjoutName.Text = maRequeteParId.UserFirstName;
                AjoutName2.Text = maRequeteParId.UserLastName;
                AjoutEmail.Text = maRequeteParId.EmailAddress;
                AjoutCompagny.Text = maRequeteParId.CompanyName;
                AjoutPhone.Text = maRequeteParId.Phone;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Id non trouvé !" , "Error ID" , MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Button_Supp(object sender, RoutedEventArgs e)
        {
            string idShow = IdShow.Text;
            var maRequeteParId = await _client.DeleteById(idShow);
            MessageBox.Show("Supprimé avec succès", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private async void Button_Ajouter(object sender, RoutedEventArgs e)
        {
            string newName = AjoutName.Text;
            string newLastName = AjoutName2.Text;
            string newEmail = AjoutEmail.Text;
            string newCompany = AjoutCompagny.Text;
            string newPhone = AjoutPhone.Text;

            UserInfoDto newDto = new UserInfoDto( );
            newDto.UserFirstName = newName;
            newDto.UserLastName = newLastName;
            newDto.EmailAddress = newEmail;
            newDto.CompanyName = newCompany;
            newDto.Phone = newPhone;
            
            var maRequeteAll = await _client.Post(newDto);
            MessageBox.Show("Ajouté avec succès", "ADD", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void Button_Editer(object sender, RoutedEventArgs e)
        {
            string idShow = IdShow.Text;
            string newFirstName = AjoutName.Text;
            string newLastName = AjoutName2.Text;
            string newEmail = AjoutEmail.Text;
            string newCompanyName = AjoutCompagny.Text;
            string newPhone = AjoutPhone.Text;

            var newDto = new UserInfoDto( );
            newDto.UserFirstName = newFirstName;
            newDto.UserLastName = newLastName;
            newDto.EmailAddress= newEmail;
            newDto.CompanyName = newCompanyName;
            newDto.Phone = newPhone;

            var maRequeteAll = await _client.UpdateById(newDto, idShow);
            MessageBox.Show("Edité avec succès", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var maRequeteAll = await _client.GetAll();

            var Users = _mapper.Map<IEnumerable<UserInfoModel>>(maRequeteAll);

            UsersList.Users = new ObservableCollection<UserInfoModel>(Users);

        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


    }

}
