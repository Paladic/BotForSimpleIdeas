using Discord;
using Discord.Interactions;
using Fergun.Interactive;

namespace BotForSimpleIdeas.Commands;

public class Command : InteractionModuleBase<SocketInteractionContext>
{
    public InteractiveService Interactive { get;}
    
    public Command(InteractiveService interactive)
    {
        Interactive = interactive;
    }

    [SlashCommand("симпл-разбанить", "разблокирует всех юзеров")]
    [DefaultMemberPermissions(GuildPermission.Administrator)]
    [EnabledInDm(false)]
    public async Task CheckUserAwardsAsync()
    {
        await DeferAsync();
        var bans = Context.Guild.GetBansAsync();
        await foreach (var ban in bans)
        {
            foreach (var cur in ban)
            {
                await Context.Guild.RemoveBanAsync(cur.User);
                await Context.Channel.SendMessageAsync($"{cur.User} разбанен");
                await Task.Delay(1 * 1000);
            }
        }
    }
    

}