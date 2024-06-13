import { Point2D } from "./Point2D";

export class Hexagon2D {
  public constructor(init?: Partial<Hexagon2D>) {
    Object.assign(this, init);
}

    position: Point2D = new Point2D;
}