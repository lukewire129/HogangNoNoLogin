using System;

namespace HogangNoNo_Toy_mauiReactor.Pages.Components;

public class BottomButtonState
{
        public Color backGround { get; set; }
        public Color textColor { get; set; }
}
public class BottomButton : Component<BottomButtonState>
{
        private string _text;
        private bool _state;
        private Action NextPage;
        public BottomButton(string text)
        {
                this._text = text;
        }
        public BottomButton OnTap(Action action)
        {
                NextPage = action;
                return this;
        }

        protected override void OnMounted()
        {
                Initilize();
                base.OnMounted();
        }

        protected override void OnPropsChanged()
        {
                Initilize();
                base.OnPropsChanged();
        }

        private void Initilize()
        {
                State.backGround = _state ? Color.FromArgb("#584DE3") : Color.FromArgb("#F0F0F0");
                State.textColor = _state ? Colors.White : Color.FromArgb("#E1E1E1");
        }

        
        public BottomButton IsEnabled(bool state)
        {
                _state = state;
                return this;
        }

        public override VisualNode Render()
        {
                return new ContentView()
                {
                        StateLabel()
                        .TextColor(State.textColor)
                        .BackgroundColor(State.backGround)
                        .VEnd()
                        .OnTapped(Next)
                };
        }

        private void Next()
        {
                NextPage.Invoke();
        }
        private Label StateLabel()
        {
                return new Label(this._text)
                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                        .HeightRequest(70)
                        .VerticalTextAlignment(TextAlignment.Center)
                        .HorizontalTextAlignment(TextAlignment.Center);
        }
}
