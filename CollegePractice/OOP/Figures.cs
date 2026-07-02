using System;
using System.Numerics;

namespace CollegePractice.OOP;

public abstract class Figure
{
    /// <summary>
    /// Позиция фигуры
    /// </summary>
    private Vector2 _position;
    public virtual Vector2 Position
    {
        get => _position; 
        set
        {
            if (value.X < 0  || value.Y < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Координаты позиции фигуры не могут быть отрицательными!");
            _position = value;
        }
    }

    /// <summary>
    /// Периметр фигуры.
    /// </summary>
    public abstract float Perimeter { get; }

    /// <summary>
    /// Площадь фигуры.
    /// </summary>
    public abstract float Area { get; }
}

public class Rectangle : Figure
{
    private float _width;
    private float _height;
    
    public Rectangle(Vector2 position, float width, float height)
    {
        Position = position;
        Width = width;
        Height = height;
    }
    
    public float Width
    {
        get => _width;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Ширина фигуры не может быть отрицательной!");
            _width = value;
        }
    }
    
    public float Height
    {
        get => _height;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Высота фигуры не может быть отрицательной!");
            _height = value;
        }
    }
    
    public override float Perimeter => (Width + Height) * 2f;
    
    public override float Area => Width * Height;
    
    public override string ToString()
    {
        return $"Прямоугольник в точке {Position}, ширина={Width}, высота={Height}, " +
               $"периметр={Perimeter:F2}, площадь={Area:F2}";
    }
}