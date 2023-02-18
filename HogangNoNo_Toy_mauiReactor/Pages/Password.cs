using MauiReactor;

namespace HogangNoNo_Toy_mauiReactor.Pages
{
        public class Password : Component
        {
                public override VisualNode Render()
                {
                        return new ContentPage()
                        {
                                new VStack(5)
                                {
                                        new Entry()
                                        .Placeholder("가입시 사용한 휴대전화 또는 이메일"),

                                        new Label("비밀번호를 찾기 원하는 휴대전화번호 또는 이메일 아이디를 입력해주세요.")
                                        .TextColor(Color.FromArgb("#DDCCCCCC"))
                                        .Padding(10,0)
                                }
                        }
                        .Title("비밀번호 찾기")
                        .Padding(10);
                }
        }
}
