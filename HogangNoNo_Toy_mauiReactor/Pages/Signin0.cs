using HogangNoNo_Toy_mauiReactor.Pages.Components;
using System.Linq;

namespace HogangNoNo_Toy_mauiReactor.Pages;

public class Signin0State
{
        public string phoneNumber { get; set; }
        public string authNumber { get; set; }
        public bool isAuthNumber { get; set; }

        public bool IsPhoneNumberFocusedEntry { get; set; }
        public bool IsAuthNumberFocusedEntry { get; set; }

        public bool IsAuthNumberReq { get; set; }

}

public class Signin0 : Component<Signin0State>
{
        protected override void OnMounted()
        {
                State.IsAuthNumberReq = false;
                BottomButtonEnable();
                base.OnMounted();
        }

        public override VisualNode Render()
        {
                return new ContentPage()
                {
                        new Grid()
                        {
                                new VStack(5)
                                {
                                        new CustomEntry("010", State.phoneNumber)
                                                .OnTextChanged((v)=>
                                                        {
                                                                SetState(s=>s.phoneNumber = v);
                                                                BottomButtonEnable();
                                                        })
                                                .OnFocused((v)=> SetState(s=>s.IsPhoneNumberFocusedEntry = v))
                                                .IsFocused(State.IsPhoneNumberFocusedEntry),

                                        new CustomEntry("인증번호", State.authNumber)
                                                .OnTextChanged((v)=>
                                                        {
                                                                SetState(s=>s.authNumber = v);
                                                                BottomButtonEnable();

                                                                IsAuthCheck();
                                                        })
                                                .OnFocused((v)=> SetState(s=>s.IsAuthNumberFocusedEntry = v))
                                                .IsFocused(State.IsAuthNumberFocusedEntry)
                                                .IsVisible(State.isAuthNumber),

                                        new Label("휴대전화번호 인증이 필요합니다. 휴대전화번호는 외부에 노출하지 않습니다.")
                                                .TextColor(Color.FromArgb("#DDCCCCCC"))
                                                .Padding(10,0)
                                }
                                .Padding(10),

                                new BottomStateButton(State.IsAuthNumberReq? "2:59" : "인증번호받기")
                                        .IsEnabled(State.isAuthNumber)
                                        .OnTap(Next)
                        }
                }
                .Title("일반 회원 가입");
        }

        private void BottomButtonEnable()
        {
                SetState(s => s.isAuthNumber = IsActiveAuth());
        }

        private void Next()
        {
                if (State.IsAuthNumberReq == true)
                        return;

                SetState(s => s.IsAuthNumberReq = true);                
        }

        private async void IsAuthCheck()
        {
                if (State.IsAuthNumberReq == false)
                        return;

                // 요기에 인증번호 일치하는지 묻는거 추가하면됨
                if (State.authNumber != "1234")
                        return;

                SetState(s => s.phoneNumber = "");
                SetState(s => s.authNumber = "");
                SetState(s => s.IsPhoneNumberFocusedEntry = false);
                SetState(s => s.IsAuthNumberFocusedEntry = false);
                SetState(s => s.IsAuthNumberReq = false);
                BottomButtonEnable();

                await Navigation.PushAsync<Signin1>();
        }

        private bool IsActiveAuth()
        {
                if (State.phoneNumber == null)
                        return false;

                if (State.phoneNumber.Count() < 11)
                        return false;

                return true;
        }
}
