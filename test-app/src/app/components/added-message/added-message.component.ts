import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { ContactsService } from "@app/services/contacts.service";
import { ThemesService } from "@app/services/themes.service";
import { MessagesService } from "@services/mesages.service";
import { catchError, forkJoin, Subject, switchMap, takeUntil } from "rxjs";

@Component({
  selector: "app-added-message",
  imports: [CommonModule],
  templateUrl: "./added-message.component.html",
  styleUrl: "./added-message.component.css",
})
export class AddedMessageComponent implements OnInit {
  id: number = 0;
  private destroy$ = new Subject<void>();
  data: any = {
    userName: "",
    email: "",
    phoneNubmer: "",
    theme: "",
    message: "",
  };
  constructor(
    private contactsService: ContactsService,
    private messagesService: MessagesService,
    private themesService: ThemesService
  ) {}
  ngOnInit(): void {
    this.id = history.state.id;

    this.messagesService
      .getMessageById(this.id)
      .pipe(
        takeUntil(this.destroy$), // Отмена подписки при уничтожении компонента
        switchMap((message) => {
          this.data.message = message.content;
          return forkJoin({
            contact: this.contactsService.getContactById(message.contactId),
            theme: this.themesService.getThemeById(message.themeId),
          });
        }),
        catchError((error) => {
          console.error("Ошибка при загрузке данных:", error);
          throw error;
        })
      )
      .subscribe({
        next: ({ contact, theme }) => {
          this.data.userName = contact.userName;
          this.data.email = contact.email;
          this.data.phoneNubmer = contact.phoneNumber;
          this.data.theme = theme.themeLabel;
        },
        error: (error) => {
          console.error("Ошибка при загрузке данных:", error);
        },
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(); // Отмена всех подписок
    this.destroy$.complete();
  }
}
