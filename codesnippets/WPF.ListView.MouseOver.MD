```xml
				<ListView.ItemContainerStyle>
					<Style TargetType="{x:Type ListViewItem}">
						<Setter Property="Border.Background" Value="Blue"/>
						<Style.Triggers>
							<Trigger Property="Border.IsMouseOver" Value="True">
								<Setter Property="Border.Background" Value="Green" />
							</Trigger>
						</Style.Triggers>
					</Style>
				</ListView.ItemContainerStyle>
			</ListView>
```