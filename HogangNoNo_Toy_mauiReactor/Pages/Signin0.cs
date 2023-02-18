
using MauiReactor;

namespace HogangNoNo_Toy_mauiReactor.Pages
{
        public class Signin0 : Component
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
                                                .Placeholder("010"),

                                                new Label("휴대전화번호 인증이 필요합니다. 휴대전화번호는 외부에 노출하지 않습니다.")
                                                .TextColor(Color.FromArgb("#DDCCCCCC"))
                                                .Padding(10,0)
                                        }
                                        .Padding(10),

                                         new Label("인증번호받기")
                                        .TextColor(Colors.White)
                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                        .BackgroundColor(Color.FromArgb("#584DE3"))
                                        .HeightRequest(70)
                                        .VerticalTextAlignment(TextAlignment.Center)
                                        .HorizontalTextAlignment(TextAlignment.Center)
                                        .VEnd()
                                        .OnTapped(Next)
                                }
                        }
                        .Title("일반 회원 가입");
                }

                private async void Next()
                {
                        await Navigation.PushAsync<Signin1>();
                }
        }
}
