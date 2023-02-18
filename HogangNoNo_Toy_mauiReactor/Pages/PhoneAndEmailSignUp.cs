
using MauiReactor;
using System.Threading.Tasks;

namespace HogangNoNo_Toy_mauiReactor.Pages
{
        public class PhoneAndEmailSignUp : Component
        {
                public override VisualNode Render()
                {
                        return new ContentPage()
                        {
                                new Grid()
                                {
                                        new VStack(5)
                                        {
                                                new Entry()
                                                .Placeholder("휴대전화번호 또는 이메일"),

                                                new Entry()
                                                .Placeholder("비밀번호"),

                                                new Grid()
                                                {
                                                        new Label("회원 가입")
                                                        .OnTapped(SignIn)
                                                        .HStart()
                                                        ,

                                                        new Label("비밀 번호 찾기")
                                                        .OnTapped(Password)
                                                        .HEnd()
                                                        ,
                                                }
                                        }.Padding(10),

                                        new Label("로그인")
                                        .TextColor(Colors.White)
                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                        .BackgroundColor(Color.FromArgb("#584DE3"))
                                        .HeightRequest(70)
                                        .VerticalTextAlignment(TextAlignment.Center)
                                        .HorizontalTextAlignment(TextAlignment.Center)
                                        .VEnd()
                                }
                        }
                        .Title("휴대전화 / 이메일 로그인")
                        ;
                }

                private async void SignIn()
                {
                        await Navigation.PushAsync<Signin0>();
                }

                private async void Password()
                {
                        await Navigation.PushAsync<Password>();
                }
        }
}
