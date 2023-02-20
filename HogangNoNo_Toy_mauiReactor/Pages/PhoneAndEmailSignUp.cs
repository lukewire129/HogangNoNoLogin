using HogangNoNo_Toy_mauiReactor.Pages.Components;
using MauiReactor.Compatibility;
using System;
using System.Linq;

namespace HogangNoNo_Toy_mauiReactor.Pages;

public class PhoneAndEmailSignUpState
{
        public string id { get; set; }
        public string password { get; set; }
        public bool isNextButton { get; set; }

        public bool IsIdFocusedEntry { get; set; }
        public bool IsPWFocusedEntry { get; set; }
}

public class PhoneAndEmailSignUp : Component<PhoneAndEmailSignUpState>
{
        protected override void OnMounted()
        {
                State.isNextButton = IsActiveNextButton();
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
                                       new CustomEntry("휴대전화번호 또는 이메일", State.id)
                                               .OnTextChanged((v)=>
                                               {
                                                       SetState(s=>s.id = v);
                                                       SetState(s=>s.isNextButton = IsActiveNextButton());
                                               })
                                               .OnFocused((v)=> SetState(s=>s.IsIdFocusedEntry = v))
                                               .IsFocused(State.IsIdFocusedEntry),

                                       new CustomEntry("비밀번호", State.password)
                                               .OnTextChanged((v)=>
                                               {
                                                       SetState(s=>s.password = v);
                                                       SetState(s=>s.isNextButton = IsActiveNextButton());
                                               })
                                               .OnFocused((v)=> SetState(s=>s.IsPWFocusedEntry = v))
                                               .IsFocused(State.IsPWFocusedEntry),

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

                                new BottomStateButton("로그인")
                                .IsEnabled(State.isNextButton)
                                .OnTap(Next)
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

        private async void Next()
        {
                //await Navigation.PushAsync<Signin1>();
        }

        private bool IsActiveNextButton()
        {
                if (State.id == null)
                        return false;
                if (State.password == null)
                        return false;

                if (State.id.Contains("@") == true)
                        return true;

                return IsPhoneNumber(State.id);
        }

        private bool IsPhoneNumber(string text)
        {
                bool ret = text.All(Char.IsDigit);
                if (ret == false)
                        return false;

                if (text.Count() < 11)
                        return false;

                return true;
        }
}
