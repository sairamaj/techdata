# Command binding to Ctrl Keys

```xml
<UserControl.Resources>
		<ControlTemplate x:Key="templateWithJustTextBox">
			<Viewbox StretchDirection="DownOnly" Stretch="Uniform">
				<TextBlock Text="{Binding}" HorizontalAlignment="Center"/>
			</Viewbox>
			<!--<StackPanel Orientation="Horizontal">
				<TextBlock  Text="{Binding}"/>
			</StackPanel>-->
		</ControlTemplate>
		<ControlTemplate x:Key="templateWithJustTextBoxWithEdit">
			<StackPanel Orientation="Horizontal">
				<TextBlock  Text="{Binding}"/>
				<Image Source="../images/edit.png" Margin="5,0,0,0"/>
			</StackPanel>
		</ControlTemplate>
	</UserControl.Resources>
 	<ContentControl>
		<ContentControl.Style>
			<Style TargetType="ContentControl">
				<Setter Property="Template" Value="{StaticResource templateWithJustTextBox}"/>
				<Style.Triggers>
					<Trigger Property="IsMouseOver" Value="True">
						<Setter Property="Template" Value="{StaticResource templateWithJustTextBoxWithEdit}"/>
					</Trigger>
				</Style.Triggers>
			</Style>
		</ContentControl.Style>
	</ContentControl>


```
