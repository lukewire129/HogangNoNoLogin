using HogangNoNo_Toy_mauiReactor.Pages.Components;
using MauiReactor;

namespace HogangNoNo_Toy_mauiReactor.Pages;

public class Signin1State
{
        public string password { get; set; }
        public string password1 { get; set; }
        public string year { get; set; }

        public bool IsPasswordFocusedEntry { get; set; }
        public bool IsPassword1FocusedEntry { get; set; }
        public bool IsYearFocusedEntry { get; set; }
}
public class Signin1 : Component<Signin1State>
{
        public override VisualNode Render()
        {
                return new ContentPage()
                {
                        new Grid()
                        {
                                new VStack(5)
                                {
                                        new CustomEntry("비밀번호(10자리 이상)", State.password)
                                                .OnTextChanged((v)=>
                                                        {
                                                                SetState(s=>s.password = v);
                                                        })
                                                .OnFocused((v)=> SetState(s=>s.IsPasswordFocusedEntry = v))
                                                .IsFocused(State.IsPasswordFocusedEntry),

                                        new CustomEntry("비밀번호 재확인", State.password1)
                                                .OnTextChanged((v)=>
                                                        {
                                                                SetState(s=>s.password1 = v);
                                                        })
                                                .OnFocused((v)=> SetState(s=>s.IsPassword1FocusedEntry = v))
                                                .IsFocused(State.IsPassword1FocusedEntry),

                                        new Grid()
                                        {
                                                new Grid("*", "60, auto, auto")
                                                {
                                                        new CustomEntry("****", State.year)
                                                                .OnTextChanged((v)=>
                                                                        {
                                                                                SetState(s=>s.year = v);
                                                                        })
                                                                .OnFocused((v)=> SetState(s=>s.IsYearFocusedEntry = v))
                                                                .IsFocused(State.IsYearFocusedEntry)
                                                                .GridColumn(0),

                                                        new Label("년생")
                                                                .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                                .FontSize(15)
                                                                .VCenter()
                                                                .GridColumn(1),

                                                          new Label("(선택)")
                                                                .VCenter()
                                                                .FontSize(13)
                                                                .TextColor(Color.FromRgba("#7D83C8"))
                                                                .GridColumn(2)
                                                }
                                                .HStart(),

                                                new HStack(-1)
                                                {
                                                        ToggleButton("남자"),
                                                        ToggleButton("여자"),
                                                }
                                                .HEnd()
                                        },
                                        
                                        new HStack(0)
                                        {
                                                new RadioButton()
                                                        .BorderColor(Color.FromRgba("#cccccc")),

                                                new Label("전체 동의")
                                                        .VCenter()
                                        },

                                        new Frame()
                                        {

                                        }
                                }
                                .Padding(10),
                        }
                }
                .Title("회원 정보 입력");
        }

        private Button ToggleButton(string text)
        {
                return new Button(text)
                        .BorderWidth(1)
                        .BorderColor(Color.FromRgba("#cccccc"))
                        .CornerRadius(0)
                        .BackgroundColor(Colors.Transparent)
                        .WidthRequest(70)
                        .HeightRequest(40)
                        .TextColor(Color.FromRgba("#cccccc"))
                        .FontSize(14)
                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                        ;
        }

        private async void Next()
        {
                await Navigation.PopToRootAsync();
        }
}
