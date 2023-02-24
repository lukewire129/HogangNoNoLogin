using HogangNoNo_Toy_mauiReactor.Controls;
using MauiReactor;
using MauiReactor.Compatibility;
using System;
using System.Linq;

namespace HogangNoNo_Toy_mauiReactor.Pages.Components
{
        public class CustomEntryState
        {
                public Color BorderColor { get; set; }
        }
        internal class CustomEntry : Component<CustomEntryState>
        {
                private string _placaHolder;
                private string _txt;
                private Action<String> _OnTextChanged;
                private Action<bool> _OnFocused;
                
                private bool _focused;
                private bool _isVisible = true;
                public CustomEntry(string PlaceHolder, 
                                   string txt)
                {
                        this._placaHolder = PlaceHolder;
                        this._txt = txt;
                }

                public CustomEntry IsVisible(bool state)
                {
                        _isVisible = state;
                        return this;
                }

                public CustomEntry IsFocused(bool state)
                {
                        this._focused = state;
                        return this;
                }
                public CustomEntry OnFocused(Action<bool> action)
                {
                        _OnFocused = action;
                        return this;
                }

                public CustomEntry OnTextChanged(Action<String> action)
                {
                        _OnTextChanged = action;
                        return this;
                }

                protected override void OnMounted()
                {
                        State.BorderColor = this._focused ? Color.FromRgba("#4E55BD") : Color.FromRgba("#cccccc");
                        base.OnMounted();
                }

                protected override void OnPropsChanged()
                {
                        State.BorderColor = this._focused ? Color.FromRgba("#4E55BD") : Color.FromRgba("#cccccc");
                        base.OnPropsChanged();
                }

                public override VisualNode Render()
                {
                        if (_isVisible == false)
                                return new Grid();

                        return new Frame()
                                {
                                        new BorderlessEntry()
                                                .Placeholder(_placaHolder)
                                                .Text(_txt)
                                                .CursorPosition(_txt == null? 0 : _txt.Count())
                                                .OnTextChanged(_OnTextChanged)
                                                .OnFocused(()=>
                                                        {
                                                                FocusedEvent(true);
                                                        })
                                                .OnUnfocused(()=>
                                                        {
                                                                FocusedEvent(false);
                                                        })
                                }
                                .Padding(10, 2)
                                .BorderColor(State.BorderColor);
                }

                private void FocusedEvent(bool state)
                {
                        this._OnFocused.Invoke(state);
                }
        }
}
