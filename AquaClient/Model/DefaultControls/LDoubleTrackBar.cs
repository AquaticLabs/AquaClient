using System.Drawing.Drawing2D;

namespace AquaClient.Model.DefaultControls;

public class LDoubleTrackBar : Control
{
    public LDoubleTrackBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        CreateControl();
    }


    private MouseStatus mouseStatus = MouseStatus.Leave;
    private PointF mousePoint = Point.Empty;


    #region Ctrls

    private Color _BarColor = Color.FromArgb(128, 255, 128);


    public Color L_BarColor
    {
        get => _BarColor;
        set
        {
            _BarColor = value;
            Invalidate();
        }
    }

    private Color _SliderColor = Color.FromArgb(0, 192, 0);


    public Color L_SliderColor
    {
        get => _SliderColor;
        set
        {
            _SliderColor = value;
            Invalidate();
        }
    }

    private bool _IsRound = true;

    public bool L_IsRound
    {
        get => _IsRound;
        set
        {
            _IsRound = value;
            Invalidate();
        }
    }

    private double _Minimum = 0;

    public double L_Minimum
    {
        get => _Minimum;
        set
        {
            _Minimum = value;
            Invalidate();
        }
    }

    private double _Maximum = 0;

    public double L_Maximum
    {
        get => _Maximum;
        set
        {
            _Maximum = value;
            Invalidate();
        }
    }

    private double _Value = 0;

    public double L_Value
    {
        get => _Value;
        set
        {
            _Value = value;
            Invalidate();
        }
    }

    private int _BarSize = 0;

    public int L_BarSize
    {
        get => _BarSize;
        set
        {
            _BarSize = value;
            if (_BarSize < 1) _BarSize = 1;

            if (_Orientation == LTrackBarOrientation.Horizontal_LR ||
                _Orientation == LTrackBarOrientation.Horizontal_RL)
            {
                Size = new Size(Width, _BarSize);
            }
            else
            {
                Size = new Size(_BarSize, Height);
            }
        }
    }

    #endregion


    private void pValueToPoint()
    {
        float fCapHalfWidth = 0;
        float fCapWidth = 0;
        if (_IsRound)
        {
            fCapWidth = _BarSize;
            fCapHalfWidth = _BarSize / 2.0f;
        }

        var fRatio = (float)((_Value - _Minimum) / (_Maximum - _Minimum));
        if (_Orientation == LTrackBarOrientation.Horizontal_LR)
        {
            
            var fPointValue = Math.Round(fRatio * (Width - fCapWidth) + fCapHalfWidth, 2);
            mousePoint = new PointF((float)fPointValue, fCapHalfWidth);
        }
        else if (_Orientation == LTrackBarOrientation.Horizontal_RL)
        {
            var fPointValue = Width - fCapHalfWidth - fRatio * (Width - fCapWidth);
            mousePoint = new PointF(fPointValue, fCapHalfWidth);
        }
        else if (_Orientation == LTrackBarOrientation.Vertical_TB)
        {
            var fPointValue = fRatio * (Height - fCapWidth) + fCapHalfWidth;
            mousePoint = new PointF(fCapHalfWidth, fPointValue);
        }
        else
        {
            var fPointValue = Height - fCapHalfWidth - fRatio * (Height - fCapWidth);
            mousePoint = new PointF(fCapHalfWidth, fPointValue);
        }
    }

    private void pPointToValue()
    {
        float fCapHalfWidth = 0;
        float fCapWidth = 0;
        if (_IsRound)
        {
            fCapWidth = _BarSize;
            fCapHalfWidth = _BarSize / 2.0f;
        }

        if (_Orientation == LTrackBarOrientation.Horizontal_LR)
        {
            var fRatio = Math.Round((mousePoint.X - fCapHalfWidth) / (Width - fCapWidth), 2);
            _Value = Math.Round(fRatio * (_Maximum - _Minimum) + _Minimum, 2);
        }
        else if (_Orientation == LTrackBarOrientation.Horizontal_RL)
        {
            var fRatio = Math.Round((Width - mousePoint.X - fCapHalfWidth) / (Width - fCapWidth), 2);
            _Value = Math.Round(fRatio * (_Maximum - _Minimum) + _Minimum, 2);
        }
        else if (_Orientation == LTrackBarOrientation.Vertical_TB)
        {
            var fRatio = Math.Round((mousePoint.Y - fCapHalfWidth) / (Height - fCapWidth), 2);
            _Value = Math.Round(fRatio * (_Maximum - _Minimum) + _Minimum, 2);
        }
        else
        {
            var fRatio = Convert.ToSingle(Height - mousePoint.Y - fCapHalfWidth) / (Height - fCapWidth);
            _Value = Math.Round(fRatio * (_Maximum - _Minimum) + _Minimum, 2);
        }

        if (_Value < _Minimum) _Value = _Minimum;
        if (_Value > _Maximum) _Value = _Maximum;
        LValueChanged?.Invoke(this, new LEventArgs(_Value));
    }


    private LTrackBarOrientation _Orientation = 0;

    public LTrackBarOrientation L_Orientation
    {
        get => _Orientation;
        set
        {
            var old = _Orientation;
            _Orientation = value;
            if ((old == LTrackBarOrientation.Horizontal_LR || old == LTrackBarOrientation.Horizontal_RL) &&
                (_Orientation == LTrackBarOrientation.Vertical_BT || _Orientation == LTrackBarOrientation.Vertical_TB))
            {
                Size = new Size(Size.Height, Size.Width);
            }

            if ((_Orientation == LTrackBarOrientation.Horizontal_LR ||
                 _Orientation == LTrackBarOrientation.Horizontal_RL) &&
                (old == LTrackBarOrientation.Vertical_BT || old == LTrackBarOrientation.Vertical_TB))
            {
                Size = new Size(Size.Height, Size.Width);
            }

            Invalidate();
        }
    }


    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        int iHeight = _BarSize;
        if (_Orientation == LTrackBarOrientation.Horizontal_LR ||
            _Orientation == LTrackBarOrientation.Horizontal_RL)
        {
            base.SetBoundsCore(x, y, width, iHeight, specified);
        }
        else
        {
            base.SetBoundsCore(x, y, iHeight, height, specified);
        }
    }

    public delegate void LValueChangedEventHandler(object sender, LEventArgs e);

    public event LValueChangedEventHandler LValueChanged;


    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        pValueToPoint();
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

        Pen penBarBack = new Pen(_BarColor, _BarSize);
        Pen penBarFore = new Pen(_SliderColor, _BarSize);

        float fCapHalfWidth = 0;
        float fCapWidth = 0;
        if (_IsRound)
        {
            fCapWidth = _BarSize;
            fCapHalfWidth = _BarSize / 2.0f;
            penBarBack.StartCap = LineCap.Round;
            penBarBack.EndCap = LineCap.Round;

            penBarFore.StartCap = LineCap.Round;
            penBarFore.EndCap = LineCap.Round;
        }

        float fPointValue = 0;
        if (_Orientation == LTrackBarOrientation.Horizontal_LR || _Orientation == LTrackBarOrientation.Horizontal_RL)
        {
            e.Graphics.DrawLine(penBarBack, fCapHalfWidth, Height / 2f, Width - fCapHalfWidth, Height / 2f);

            fPointValue = mousePoint.X;
            if (fPointValue < fCapHalfWidth) fPointValue = fCapHalfWidth;
            if (fPointValue > Width - fCapHalfWidth) fPointValue = Width - fCapHalfWidth;
        }
        else
        {
            e.Graphics.DrawLine(penBarBack, Width / 2f, fCapHalfWidth, Width / 2f, Height - fCapHalfWidth);

            fPointValue = mousePoint.Y;
            if (fPointValue < fCapHalfWidth) fPointValue = fCapHalfWidth;
            if (fPointValue > Height - fCapHalfWidth) fPointValue = Height - fCapHalfWidth;
        }


        if (_Orientation == LTrackBarOrientation.Horizontal_LR)
        {
            e.Graphics.DrawLine(penBarFore, fCapHalfWidth, Height / 2f, fPointValue, Height / 2f);
        }
        else if (_Orientation == LTrackBarOrientation.Horizontal_RL)
        {
            e.Graphics.DrawLine(penBarFore, fPointValue, Height / 2f, Width - fCapHalfWidth, Height / 2f);
        }
        else if (_Orientation == LTrackBarOrientation.Vertical_TB)
        {
            e.Graphics.DrawLine(penBarFore, Width / 2f, fCapHalfWidth, Width / 2f, fPointValue);
        }
        else
        {
            e.Graphics.DrawLine(penBarFore, Width / 2f, fPointValue, Width / 2f, Height - fCapHalfWidth);
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (mouseStatus == MouseStatus.Down)
        {
            mousePoint = e.Location;
            pPointToValue();
            Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        mouseStatus = MouseStatus.Up;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        mouseStatus = MouseStatus.Down;
        mousePoint = e.Location;
        pPointToValue();
        Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        mouseStatus = MouseStatus.Enter;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        mouseStatus = MouseStatus.Leave;
    }
}