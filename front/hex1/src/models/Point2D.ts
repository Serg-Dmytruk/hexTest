export class Point2D{

     public constructor(init?: Partial<Point2D>) {
        Object.assign(this, init);
    }

    x:number = 0;
    y:number = 0;
}