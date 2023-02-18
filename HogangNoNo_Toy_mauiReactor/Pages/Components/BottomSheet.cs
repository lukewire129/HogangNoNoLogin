using MauiReactor;
using MauiReactor.Shapes;
using System;

namespace HogangNoNo_Toy_mauiReactor.Pages.Components
{
        class BottomSheetState
        {
                public bool state { get; set; }
                public double TranslateY { get; set; }
                public double opacity { get; set; }
        }

        internal class BottomSheet : Component<BottomSheetState>
        {
                private bool _state;
                private Action _onShowOnboarding;
                public BottomSheet isShow(bool state)
                {
                        _state = state;
                        return this;
                }
                public BottomSheet OnShowOnboarding(Action action)
                {
                        _onShowOnboarding = action;
                        return this;
                }

                protected override void OnMounted()
                {
                        State.TranslateY = _state ? 0 : 250;
                        State.opacity = _state ? 0.7 : 0;
                        base.OnMounted();
                }
                protected override void OnPropsChanged()
                {
                        State.TranslateY = _state ? 0 : 250;
                        State.opacity = _state ? 0.7 : 0;
                        base.OnPropsChanged();
                }

                public override VisualNode Render()
                {
                        return new Grid()
                        {
                                new Grid()
                                 .BackgroundColor(Color.FromArgb("#DDCCCCCC"))
                                 .Opacity(State.opacity)
                                 .WithAnimation(easing: Easing.CubicIn, duration: 300),

                                new Border()
                                {
                                        new VStack(30)
                                        {
                                                new Grid()
                                                {
                                                        new Label("다른 방법으로 로그인")
                                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                        .HStart(),

                                                        new Label("닫기")
                                                        .HEnd()
                                                        .OnTapped(Back)
                                                },

                                                new VStack(5)
                                                {
                                                        new Button("휴대전화/이메일로 시작하기")
                                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                        .TextColor(Colors.White)
                                                        .BackgroundColor(Color.FromRgba("#584DE3"))
                                                        .CornerRadius(5)
                                                        .HeightRequest(50)
                                                        .FontSize(12)
                                                        .OnClicked(PersonalSignUp),

                                                        new Button("페이스북으로 시작하기")
                                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                        .BackgroundColor(Color.FromRgba("#1878F2"))
                                                        .TextColor(Colors.White)
                                                        .BorderColor(Color.FromRgba("#cccccc"))
                                                        .CornerRadius(5)
                                                        .HeightRequest(50)
                                                        .FontSize(12),

                                                        new Button("Apple로 시작하기")
                                                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                        .BackgroundColor(Colors.Transparent)
                                                        .TextColor(Colors.Black)
                                                        .BorderColor(Colors.Black)
                                                        .BorderWidth(1)
                                                        .CornerRadius(5)
                                                        .HeightRequest(50)
                                                        .FontSize(12),
                                                }
                                                .Margin(15,0)
                                        }
                                }
                                .StrokeShape(new RoundRectangle()
                                                .CornerRadius(new CornerRadius(10,10,0,0)))
                                .HeightRequest(250)
                                .StrokeThickness(0)
                                .VEnd()
                                .HFill()
                                .Padding(20, 20)
                                .TranslationY(State.TranslateY)
                                .WithAnimation(easing: Easing.CubicIn, duration: 300)
                        };
                }

                private void Back()
                {
                        _onShowOnboarding.Invoke();
                }



                private async void PersonalSignUp()
                {
                        await Navigation.PushAsync<PhoneAndEmailSignUp>();
                }
        }
}
