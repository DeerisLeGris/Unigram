using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Td.Api;
using Unigram.Common;
using Unigram.Controls;
using Unigram.Views;
using Unigram.Views.SignIn;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using Unigram.Services;
using Windows.UI.Xaml.Controls;

namespace Unigram.ViewModels.SignIn
{
    public class SignUpViewModel : UnigramViewModelBase
    {
        public SignUpViewModel(IProtoService protoService, ICacheService cacheService, ISettingsService settingsService, IEventAggregator aggregator)
            : base(protoService, cacheService, settingsService, aggregator)
        {
            SendCommand = new RelayCommand(SendExecute, () => !IsLoading);
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                Set(ref _firstName, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set(ref _lastName, value);
            }
        }

        public RelayCommand SendCommand { get; }
        private async void SendExecute()
        {
            //if (_sentCode == null)
            //{
            //    //...
            //    return;
            //}

            if (string.IsNullOrEmpty(_firstName))
            {
                RaisePropertyChanged("FIRSTNAME_INVALID");
                return;
            }

            var state = ProtoService.GetAuthorizationState();
            if (state is AuthorizationStateWaitCode waitCode && waitCode.TermsOfService != null && waitCode.TermsOfService.ShowPopup)
            {
                async void CancelSignUp()
                {
                    var decline = await TLMessageDialog.ShowAsync(Strings.Resources.TosUpdateDecline, Strings.Resources.TermsOfService, Strings.Resources.DeclineDeactivate, Strings.Resources.Back);
                    if (decline != ContentDialogResult.Primary)
                    {
                        SendExecute();
                        return;
                    }

                    var delete = await TLMessageDialog.ShowAsync(Strings.Resources.TosDeclineDeleteAccount, Strings.Resources.AppName, Strings.Resources.Deactivate, Strings.Resources.Cancel);
                    if (delete != ContentDialogResult.Primary)
                    {
                        SendExecute();
                        return;
                    }

                    ProtoService.Send(new LogOut());
                }

                var confirm = await TLMessageDialog.ShowAsync(waitCode.TermsOfService.Text, Strings.Resources.TermsOfService, Strings.Resources.SignUp, Strings.Resources.Decline);
                if (confirm != ContentDialogResult.Primary)
                {
                    CancelSignUp();
                    return;
                }

                if (waitCode.TermsOfService.MinUserAge > 0)
                {
                    var age = await TLMessageDialog.ShowAsync(string.Format(Strings.Resources.TosAgeText, waitCode.TermsOfService.MinUserAge), Strings.Resources.TosAgeTitle, Strings.Resources.Agree, Strings.Resources.Cancel);
                    if (age != ContentDialogResult.Primary)
                    {
                        CancelSignUp();
                        return;
                    }
                }
            }

            await ProtoService.SendAsync(new SetOption("x_firstname", new OptionValueString(_firstName ?? string.Empty)));
            await ProtoService.SendAsync(new SetOption("x_lastname", new OptionValueString(_lastName ?? string.Empty)));

            NavigationService.Navigate(typeof(SignInSentCodePage));

            //var phoneNumber = _phoneNumber;
            //var phoneCodeHash = _sentCode.PhoneCodeHash;

            //IsLoading = true;

            //var response = await LegacyService.SignUpAsync(phoneNumber, phoneCodeHash, _phoneCode, _firstName, _lastName);
            //if (response.IsSucceeded)
            //{
            //    // TODO: maybe ask about notifications?

            //    NavigationService.Navigate(typeof(MainPage));
            //}
            //else if (response.Error != null)
            //{
            //    IsLoading = false;

            //    if (response.Error.TypeEquals(TLErrorType.PHONE_NUMBER_INVALID))
            //    {
            //        await TLMessageDialog.ShowAsync(Strings.Resources.InvalidPhoneNumber, Strings.Resources.AppName, Strings.Resources.OK);
            //    }
            //    else if (response.Error.TypeEquals(TLErrorType.PHONE_CODE_EMPTY) || response.Error.TypeEquals(TLErrorType.PHONE_CODE_INVALID))
            //    {
            //        await TLMessageDialog.ShowAsync(Strings.Resources.InvalidCode, Strings.Resources.AppName, Strings.Resources.OK);
            //    }
            //    else if (response.Error.TypeEquals(TLErrorType.PHONE_CODE_EXPIRED))
            //    {
            //        await TLMessageDialog.ShowAsync(Strings.Resources.CodeExpired, Strings.Resources.AppName, Strings.Resources.OK);
            //    }
            //    else if (response.Error.TypeEquals(TLErrorType.FIRSTNAME_INVALID))
            //    {
            //        await TLMessageDialog.ShowAsync(Strings.Resources.InvalidFirstName, Strings.Resources.AppName, Strings.Resources.OK);
            //    }
            //    else if (response.Error.TypeEquals(TLErrorType.LASTNAME_INVALID))
            //    {
            //        await TLMessageDialog.ShowAsync(Strings.Resources.InvalidLastName, Strings.Resources.AppName, Strings.Resources.OK);
            //    }
            //    else
            //    {
            //        await TLMessageDialog.ShowAsync(response.Error.ErrorMessage, Strings.Resources.AppName, Strings.Resources.OK);
            //    }
            //}
        }
    }
}
