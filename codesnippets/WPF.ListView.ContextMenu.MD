```xml
    <ListView.ContextMenu>
			    <ContextMenu Name="ZoneIformationList" StaysOpen="true" Background="WhiteSmoke">
				    <ContextMenu.BitmapEffect>
					    <BitmapEffectGroup/>
				    </ContextMenu.BitmapEffect>
				    <MenuItem Header="Item1" DataContext="{Binding PlacementTarget.SelectedItem,  RelativeSource={RelativeSource AncestorType=ContextMenu}}"
				              Command="{Binding CopyItem1Command}"
				              CommandParameter="{Binding}"							  
				    />
				    <MenuItem Header="Item2" DataContext="{Binding PlacementTarget.SelectedItem,  RelativeSource={RelativeSource AncestorType=ContextMenu}}"
				              Command="{Binding CopyItem2Command}"
				              CommandParameter="{Binding}"							  
				    />
			    </ContextMenu>
		    </ListView.ContextMenu>
```