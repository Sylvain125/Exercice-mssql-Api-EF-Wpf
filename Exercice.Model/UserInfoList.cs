using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Model
{
    public class UserInfoList : ObservableObject
    {
        private ObservableCollection<UserInfoModel> users;

        private UserInfoModel currentUser;

        public UserInfoModel CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<UserInfoModel> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }

}
