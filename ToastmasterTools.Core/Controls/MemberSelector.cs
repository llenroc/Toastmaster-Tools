using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Models;
using ToastmasterTools.UWP.Annotations;

namespace ToastmasterTools.Core.Controls
{
    public class MemberSelector: IMemberSelector, INotifyPropertyChanged
    {
        private readonly IMembersRepository _membersRepository;
        private ObservableCollection<Member> _members;

        public MemberSelector(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
            _members = new ObservableCollection<Member>();
        }

        public async Task InitializeAsync()
        {
            var report = await _membersRepository.RefreshClubMembers();
            if (report.Successful)
                Members = new ObservableCollection<Member>(report.Members);
        }

        public ObservableCollection<Member> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler<SelectionChangedEventArgs> SelectedMemberChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MemberChanged(SelectionChangedEventArgs args)
        {
            SelectedMemberChanged?.Invoke(this, args);
        }
    }
}