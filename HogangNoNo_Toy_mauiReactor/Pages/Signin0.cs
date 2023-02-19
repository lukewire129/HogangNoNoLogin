using HogangNoNo_Toy_mauiReactor.Pages.Components;
using System.Linq;

namespace HogangNoNo_Toy_mauiReactor.Pages;

public class Signin0State
{
        public string phoneNumber { get; set; }
        public bool isAuthNumber { get; set; }
}

public class Signin0 : Component<Signin0State>
{
        protected override void OnMounted()
        {
                State.isAuthNumber = IsActiveAuth();
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
                                        new Entry()
                                        .Placeholder("010")
                                        .Keyboard(Keyboard.Numeric)
                                        .MaxLength(11)
                                        .CursorPosition(State.phoneNumber == null? 0 : State.phoneNumber.Count())
                                        .OnTextChanged((_)=>
                                        {
                                                State.phoneNumber = _;
                                                SetState(s=>s.isAuthNumber =IsActiveAuth());
                                        })
                                        .Text(State.phoneNumber),

                                         new Entry()
                                         .Placeholder("인증번호")
                                         .IsVisible(State.isAuthNumber),

                                        new Label("휴대전화번호 인증이 필요합니다. 휴대전화번호는 외부에 노출하지 않습니다.")
                                        .TextColor(Color.FromArgb("#DDCCCCCC"))
                                        .Padding(10,0)
                                }
                                .Padding(10),

                                new BottomButton("인증번호받기")
                                .IsEnabled(State.isAuthNumber)
                                .OnTap(Next)
                        }
                }
                .Title("일반 회원 가입");
        }

        private async void Next()
        {
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
