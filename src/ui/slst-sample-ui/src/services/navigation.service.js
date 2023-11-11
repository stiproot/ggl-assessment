export class NavigationService {
  constructor(router) {
    this._router = router;
    this.getRouteParam = this.getRouteParam.bind(this);
  }

  getRouteParam(param) {
    return this._router.currentRoute.value.params[param];
  }
}
