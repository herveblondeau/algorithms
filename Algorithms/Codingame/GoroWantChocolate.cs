// https://www.codingame.com/training/medium/goro-want-chocolate
public class GoroWantChocolate
{

    public int GetMinimalNumberOfSquares(int width, int height)
    {
        int nbSquares = 0;

        while (width > 0 && height > 0)
        {
            if (width > height)
            {
                width -= height;
            }
            else
            {
                height -= width;
            }

            nbSquares++;
        }

        return nbSquares;
    }

}
