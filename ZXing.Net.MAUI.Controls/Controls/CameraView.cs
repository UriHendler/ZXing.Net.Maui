﻿using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace ZXing.Net.Maui.Controls
{
	public partial class CameraView : View, ICameraView
	{
		public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

		void ICameraFrameAnalyzer.FrameReady(CameraFrameBufferEventArgs e)
			=> FrameReady?.Invoke(this, e);

		public static readonly BindableProperty IsTorchOnProperty =
			BindableProperty.Create(nameof(IsTorchOn), typeof(bool), typeof(CameraView), defaultValue: true);

		public bool IsTorchOn
		{
			get => (bool)GetValue(IsTorchOnProperty);
			set => SetValue(IsTorchOnProperty, value);
		}

		public static readonly BindableProperty CameraLocationProperty =
			BindableProperty.Create(nameof(CameraLocation), typeof(CameraLocation), typeof(CameraView), defaultValue: CameraLocation.Rear);

		public CameraLocation CameraLocation
		{
			get => (CameraLocation)GetValue(CameraLocationProperty);
			set => SetValue(CameraLocationProperty, value);
		}

		public void AutoFocus()
			=> StrongHandler?.Invoke(nameof(AutoFocus), null);

		public void Focus(Point point)
			=> StrongHandler?.Invoke(nameof(Focus), point);

		CameraViewHandler StrongHandler
			=> Handler as CameraViewHandler;
	}
}
