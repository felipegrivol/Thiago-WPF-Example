namespace UI.View.Behavior
{
	#region References

	using System;
	using System.Text.RegularExpressions;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	using System.Windows.Interactivity;

	#endregion

	public class AllowableCharactersTextBoxBehavior : Behavior<TextBox>
	{
		public static readonly DependencyProperty RegularExpressionProperty =
			DependencyProperty.Register("RegularExpression", typeof(string), typeof(AllowableCharactersTextBoxBehavior),
				new FrameworkPropertyMetadata("*"));

		public static readonly DependencyProperty MaxLengthProperty =
			DependencyProperty.Register("MaxLength", typeof(int), typeof(AllowableCharactersTextBoxBehavior),
				new FrameworkPropertyMetadata(int.MaxValue));

		public string RegularExpression
		{
			get
			{
				return (string)base.GetValue(RegularExpressionProperty);
			}
			set
			{
				base.SetValue(RegularExpressionProperty, value);
			}
		}

		public int MaxLength
		{
			get
			{
				return (int)base.GetValue(MaxLengthProperty);
			}
			set
			{
				base.SetValue(MaxLengthProperty, value);
			}
		}

		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.PreviewTextInput += this.OnPreviewTextInput;
			DataObject.AddPastingHandler(this.AssociatedObject, this.OnPaste);
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.PreviewTextInput -= this.OnPreviewTextInput;
			DataObject.RemovePastingHandler(this.AssociatedObject, this.OnPaste);
		}

		private bool ExceedsMaxLength(string newText, bool paste)
		{
			if (this.MaxLength == 0)
			{
				return false;
			}

			return this.LengthOfModifiedText(newText, paste) > this.MaxLength;
		}

		private bool IsValid(string newText, bool paste)
		{
			return !this.ExceedsMaxLength(newText, paste) && Regex.IsMatch(newText, this.RegularExpression);
		}

		private int LengthOfModifiedText(string newText, bool paste)
		{
			var countOfSelectedChars = this.AssociatedObject.SelectedText.Length;
			var caretIndex = this.AssociatedObject.CaretIndex;
			string text = this.AssociatedObject.Text;

			if (countOfSelectedChars > 0 || paste)
			{
				text = text.Remove(caretIndex, countOfSelectedChars);
				return text.Length + newText.Length;
			}
			var insert = Keyboard.IsKeyToggled(Key.Insert);

			return insert && caretIndex < text.Length ? text.Length : text.Length + newText.Length;
		}

		private void OnPaste(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(DataFormats.Text))
			{
				string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));

				if (!this.IsValid(text, true))
				{
					e.CancelCommand();
				}
			}
			else
			{
				e.CancelCommand();
			}
		}

		private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !this.IsValid(e.Text, false);
		}
	}
}