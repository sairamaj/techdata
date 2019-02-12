## Textbox input validation

```xml
 <StackPanel Orientation="Horizontal">
			<TextBox Width="220" HorizontalAlignment="Left" Name="inputFileName">
				<TextBox.Text>
					<Binding Path="InputFileName" UpdateSourceTrigger="PropertyChanged"  ValidatesOnDataErrors="True" >
						<Binding.ValidationRules >
							<validators:FileNameValidator
							ErrorMessage="Required" ValidatesOnTargetUpdated="True"/>
						</Binding.ValidationRules>
					</Binding>
				</TextBox.Text>
			</TextBox>
			<Button Content="..." Command="{Binding BrowseInputFileCommand}" />
		</StackPanel>
		<TextBlock Text="{Binding (Validation.Errors)[0].ErrorContent, ElementName=inputFileName}"/>
```

```csharp
    class FileNameValidator: ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string strValue = Convert.ToString(value);
			if (string.IsNullOrWhiteSpace(strValue))
			{
				this.ErrorMessage = "File name required";
				return new ValidationResult(false, $"File name required.");
			}

			return new ValidationResult(true, null);
		}

		public string ErrorMessage { get; set; }
	}
```