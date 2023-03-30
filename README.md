<p>
  <a href="https://www.gta5-mods.com/scripts/autorotation-maneuver#description_tab" target="_blank"><img alt="Alternative Yaw Control - Keyboards" src="https://img.gta5-mods.com/q95/images/autorotation-maneuver/0816d8-autorotation-maneuver.png"/></a>
</p>


<p><strong>About the mod</strong></p>

<p>The script will add the ability to perform the autorotation maneuver, allowing you, if done correctly, to perform an emergency landing in any vehicle with rotary wings. I made this script for the simple reason that it makes no sense that I could survive the impact of a missile fired at the rear of my helicopter, but die trying to land it. Now I managed to land the whole helicopter and as a bonus blow up the bastard that hit me using the portable missile launcher.</p>

<p><strong>Requisites</strong></p>

<ul>
	<li><a href="http://www.dev-c.com/gtav/scripthookv/" target="_blank">Script Hook V - [v1.0.2699.16]</a></li>
	<li><a href="https://github.com/crosire/scripthookvdotnet/releases" target="_blank">Script Hook V DotNet - [v3.5.1]</a></li>
</ul>

<p><strong>Featured</strong></p>

<ul>
	<li>Possibility to land any vehicle with rotary wings after the loss of the engine;</li>
	<li>A simple interface that displays the rotation per minute of the blades;</li>
</ul>

<p><strong>Installation</strong></p>

<ol>
	<li>Extract from the .rar file the <em>Autorotation-maneuver.dll&nbsp;</em>file and the folder named <em>AutorotationManeuver</em>;</li>
	<li>Place the extracted files in your script folder</li>
</ol>

<p><strong>Changelog</strong></p>

<ul>
	<li>[0.4.0.0]
	<ul>
		<li>More control over the generation and use of the blade rotations generated during the autorotation maneuver, this change is very noticeable to those who use joystick with depth triggers.</li>
		<li>Increased fidelity when performing the autorotation maneuver.</li>
	</ul>
	</li>
	<li>[0.3.1.0]
	<ul>
		<li>Partial fix of the bug that causes the interface to pop up when leaving the aircraft for a brief moment. It still appears for an instant if you roll over when landing with the aircraft turned off.</li>
	</ul>
	</li>
	<li>[0.3.0.0]
	<ul>
		<li>This version brings with it two new templates for the interface. Just rename it to &quot;DefaultLayout.png&quot; to use.</li>
		<li>I made a change in the way the interface is displayed, before the interface was always visible when inside an aircraft, now the interface will only be visible when the aircraft enters autorotation.
		<ul>
			<li>The change can be undone by changing the attribute called: &quot;<em>Display Only In Autorotation</em>&quot; to &quot;<em>Off</em>&quot; in the initialization file called &quot;<em>BehaviorOfUserInterfaceElements.ini</em>&quot;.</li>
		</ul>
		</li>
	</ul>
	</li>
	<li>[0.2.0.0]
	<ul>
		<li>Improved blade speed transition and increased blade speed conservation near landing.</li>
		<li>Better code in general.</li>
	</ul>
	</li>
	<li>[0.1.0.0]
	<ul>
		<li>Initial release.</li>
	</ul>
	</li>
</ul>

