namespace HogangNoNo_Toy_mauiReactor.Pages
{
        public class Signin2 : Component
        {
                public override VisualNode Render()
                {
                        return new ContentPage()
                        {
                                new VStack(5)
                                {
                                        new Entry()
                                        .Placeholder("010"),

                                        new Entry()
                                        .Placeholder("인증번호"),

                                        new Label("휴대전화번호 인증이 필요합니다. 휴대전화번호는 외부에 노출하지 않습니다.")
                                        .TextColor(Color.FromArgb("#DDCCCCCC"))
                                        .Padding(10,0)
                                }
                        }
                        .Title("일반 회원 가입")
                        .Padding(10);
                }
        }
}
