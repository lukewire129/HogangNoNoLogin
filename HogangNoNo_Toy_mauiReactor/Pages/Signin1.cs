namespace HogangNoNo_Toy_mauiReactor.Pages
{
        public class Signin1 : Component
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
                                                .Placeholder("비밀번호(10자리 이상)"),

                                                new Entry()
                                                .Placeholder("비밀번호"),

                                                new Grid()
                                                {
                                                        new HStack(5)
                                                        {
                                                                new Entry()
                                                                .Placeholder("****")
                                                                .WidthRequest(90),

                                                                new Label("년생")
                                                                .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                                                                .FontSize(15)
                                                                .VCenter(),

                                                                new Label("(선택)")                                                                
                                                                .VCenter()
                                                                .FontSize(13)
                                                                .TextColor(Color.FromRgba("#7D83C8"))
                                                        }
                                                        .HStart(),

                                                        new HStack(-1)
                                                        {
                                                                ToggleButton("남자"),
                                                                ToggleButton("여자"),
                                                        }
                                                        .HEnd()
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
                                .HeightRequest(37)
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
}
