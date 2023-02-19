using MauiReactor;
using HogangNoNo_Toy_mauiReactor.Pages.Components;

namespace HogangNoNo_Toy_mauiReactor.Pages
{

        class LoginPageState
        {
                public bool isBottomSheet { get; set; }
        }
        internal class Login : Component<LoginPageState>
        {
                public override VisualNode Render()
                {
                        return new NavigationPage
                        {
                                Main()
                        }
                        .BarBackground(Colors.White)
                        .BarTextColor(Colors.Black);
                }

                VisualNode Main()
                {
                        return new ContentPage()
                        {
                                new Grid()
                                {
                                        new VStack(60)
                                        {
                                                new Grid("auto, auto", "*")
                                                {
                                                        new Label("아파트 실거래가는")
                                                        .TextColor(Color.FromArgb("#BBC0F0"))
                                                        .FontSize(18)
                                                        .HCenter()
                                                        .GridRow(0),

                                                        new Label("호갱노노")
                                                        .TextColor(Color.FromArgb("#5962D8"))
                                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                        .FontSize(38)
                                                        .HCenter()
                                                        .GridRow(1),
                                                },

                                                new VStack(5)
                                                {
                                                        LoginButton("카카오톡 로그인하기")
                                                        .TextColor(Color.FromRgba("#3C1D1E"))
                                                        .BackgroundColor(Color.FromRgba("#F9E001")),

                                                        LoginButton("다른 방법으로 로그인하기")
                                                        .TextColor(Colors.Black)
                                                        .BackgroundColor(Colors.Transparent)
                                                        .BorderColor(Color.FromRgba("#cccccc"))
                                                        .BorderWidth(1)
                                                        .OnClicked(()=> SetState(s=> s.isBottomSheet = !s.isBottomSheet)),

                                                        new Label("로그인하지 않고 돌아보기")
                                                        .TextColor(Color.FromRgba("#cccccc"))
                                                        .FontSize(10)
                                                        .HCenter()
                                                }
                                        }
                                        .Margin(30, 200, 30, 0),

                                        new BottomSheet()
                                        .isShow(State.isBottomSheet)
                                        .OnShowOnboarding(()=> SetState(s=> s.isBottomSheet = false))
                                }
                        }
                        .Set(MauiControls.NavigationPage.HasNavigationBarProperty, false);
                }
                Button LoginButton(string text)
                {
                        return new Button(text)
                        .FontSize(12)
                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                        .CornerRadius(5)
                        .HeightRequest(40);
                }
        }
}
