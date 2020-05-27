import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { AccountModule } from './account/account.module';
import { SharedModule } from './shared/modules/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { ConfigService } from './shared/configs/config.service';
import { PageNotFoundComponent } from './page-not-found.component';

import { MessageModule } from './messages/messages.module';
import { UserService } from './shared/services/user.service';
import { BookService } from './shared/services/book.service';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SpinnerComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AccountModule,
    SharedModule,
    MessageModule,
    HttpClientModule
  ],
  providers: [ConfigService, UserService, BookService],
  bootstrap: [AppComponent]
})
export class AppModule { }
