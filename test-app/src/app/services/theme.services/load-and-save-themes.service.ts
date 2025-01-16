import { Injectable } from "@angular/core";
import { forkJoin, Observable, switchMap } from "rxjs";
import { GetThemeService } from "./get-themes.service";
import { AddThemeService } from "./add-theme.service";

@Injectable({
  providedIn: "root",
})
export class LoadAndSaveThemesService {
  constructor(
    private getThemeService: GetThemeService,
    private addThemeService: AddThemeService
  ) {}

  loadAndSaveThemes(): Observable<any> {
    return this.getThemeService.getThemes().pipe(
      switchMap((themes) => {
        const saveRequests = themes.map((theme) =>
          this.addThemeService.addTheme(theme)
        );
        return forkJoin(saveRequests);
      })
    );
  }
}
