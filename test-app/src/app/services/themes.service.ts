import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { forkJoin, Observable, switchMap } from "rxjs";
import { Theme } from "@types";

@Injectable({
  providedIn: "root",
})
export class ThemesService {
  constructor(private http: HttpClient) {}

  addTheme(theme: Theme): Observable<any> {
    return this.http.post("http://localhost:5192/api/themes", theme);
  }
  getThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>("/assets/initialThemes.json");
  }
  getThemeById(id: number): Observable<Theme> {
    return this.http.get<Theme>(`http://localhost:5192/api/Themes/${id}`);
  }
  loadAndSaveThemes(): Observable<any> {
    return this.getThemes().pipe(
      switchMap((themes) => {
        const saveRequests = themes.map((theme) => this.addTheme(theme));
        return forkJoin(saveRequests);
      })
    );
  }
}
