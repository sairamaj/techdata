### Text box filling the width of the window

```xml
		<DockPanel Background="Orange" LastChildFill="True" Grid.Row="0" Grid.Column="0">
			<Button Content="Evaluate" Command="{Binding EvaluateExpressionCommand}" Width="60" Height="25" DockPanel.Dock="Right" Margin="0,0,10,0"/>
			<TextBlock Text="Expression:" Margin="5" 
			           DockPanel.Dock="Left" VerticalAlignment="Center"/>
			<TextBox Height="25" Width="Auto"/>
		</DockPanel >
```